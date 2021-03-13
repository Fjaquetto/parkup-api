using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ParkUp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ParkUp.Infra.Data.Context.ContextDapper
{
    public class ContextDapper : IContextDapper
    {
        #region Fields
        protected SqlConnection _connection;
        private SqlTransaction _transaction;
        private const int _COMMANDOUT = 15;
        IConfiguration _configuration;
        #endregion

        public ContextDapper(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        #region Methods
        public bool BulkCopy(DataTable dt, string tableName)
        {
            using (SqlBulkCopy bulkcopy = new SqlBulkCopy(_connection.ConnectionString, SqlBulkCopyOptions.KeepIdentity & SqlBulkCopyOptions.KeepNulls))
            {
                try
                {
                    Console.Write($"Inserindo na tabela {tableName} do banco de dados de {_connection.Database} do servidor {_connection.DataSource}...\n");
                    var columns = dt.Columns;
                    OpenConnection();
                    bulkcopy.BulkCopyTimeout = 300;
                    bulkcopy.DestinationTableName = tableName;
                    bulkcopy.WriteToServer(dt);

                    Console.WriteLine($"Total: {dt.Rows.Count} registro(s) inserido(s).\n");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("BULKCOPY ERROR: " + ex.Message + "\n");
                    throw;
                }
                finally
                {
                    CloseConnection();
                }
            }
        }

        /// <summary>
        ///  Método genérico de consulta ao banco de dados que traz uma Lista
        /// </summary>
        /// <typeparam name="T">Tipo Generico</typeparam>
        /// <param name="cmd">Query</param>
        /// <param name="param">Parametros da Query</param>
        /// <returns>Retorna uma lista de qualquer tipo genérico (entidade) do banco de dados</returns>
        public IEnumerable<T> ExecuteCollection<T>(string cmd, object param)
        {
            IEnumerable<T> resultado;
            try
            {
                Console.WriteLine($"Consultando database {_connection.Database} do servidor {_connection.DataSource}...");
                OpenConnection();
                return resultado = _connection.Query<T>(cmd, param: param, commandType: CommandType.Text, transaction: _transaction, commandTimeout: int.MaxValue);
            }
            catch (SqlException sql)
            {
                Console.WriteLine($"SQL EXCEPTION >>> {sql.Message}");
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Método genérico para trazer somente um resultado do banco
        /// </summary>
        /// <typeparam name="T">Tipo Generico</typeparam>
        /// <param name="cmd">Query</param>
        /// <param name="param">Parametros da Query</param>
        /// <returns>Retorna um objeto genérico específico</returns>
        public T ExecuteObject<T>(string cmd, object param)
        {
            T resultado;
            try
            {
                OpenConnection();
                return resultado = _connection.QuerySingleOrDefault<T>(cmd, param: param, commandType: CommandType.Text, transaction: _transaction, commandTimeout: 600);
            }
            catch (SqlException sql)
            {
                throw sql;
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Método para executar comandos DDL e DML
        /// </summary>
        /// <typeparam name="T">Tipo Generico</typeparam>
        /// <param name="cmd">Query</param>
        /// <param name="param">Parametros da Query</param>
        /// <returns>Retorna um status ou objeto com 'Success' ou 'Fail'</returns>
        public T ExecuteScalar<T>(string cmd, object param)
        {
            T resultado;
            try
            {
                OpenConnection();
                return resultado = _connection.ExecuteScalar<T>(cmd, param: param, commandType: CommandType.Text, transaction: _transaction, commandTimeout: 1200);
            }
            catch (SqlException sql)
            {
                throw sql;
            }
            finally
            {
                CloseConnection();
            }
        }

        public T ParallelObject<T>(string cmd, object param)
        {
            using (SqlConnection conn = new SqlConnection(_connection.ConnectionString))
            {
                T resultado;
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    return resultado = conn.QuerySingleOrDefault<T>(cmd, param: param, commandType: CommandType.Text, transaction: _transaction, commandTimeout: 1200);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public T ParallelScalar<T>(string cmd, object param)
        {
            using (SqlConnection conn = new SqlConnection(_connection.ConnectionString))
            {
                T resultado;
                try
                {
                    conn.Open();
                    return resultado = conn.ExecuteScalar<T>(cmd, param: param, commandType: CommandType.Text, transaction: _transaction, commandTimeout: 1200);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

        #region Open/Close Connection
        private void OpenConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                try
                {
                    _connection.Open();
                }
                catch (SqlException sql)
                {
                    throw sql;
                }
                catch (InvalidOperationException invalid)
                {
                    throw invalid;
                }
            }
        }

        private void CloseConnection()
        {
            if (_connection.State != ConnectionState.Closed)
                _connection.Close();
        }
        #endregion
    }
}
