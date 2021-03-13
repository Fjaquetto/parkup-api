using ParkUp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ParkUp.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected IContextDapper _context;
        protected IQueryBase _query;

        #region Constructors
        public Repository(IContextDapper contexto, IQueryBase query)
        {
            _context = contexto;
            _query = query;

        }
        #endregion

        #region RepositoryBaseMethods
        public virtual void Remove(object obj)
        {
            _context.ExecuteScalar<int>(_query.Remove(), obj);
        }

        public virtual IEnumerable<TEntity> GetByFilter(object obj)
        {
            return _context.ExecuteCollection<TEntity>(_query.GetByFilter(), obj);
        }

        public virtual void Update(object obj)
        {
            _context.ExecuteScalar<int>(_query.Update(), obj);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.ExecuteCollection<TEntity>(_query.GetAll(), null);
        }

        public virtual TEntity GetById(object obj)
        {
            return _context.ExecuteObject<TEntity>(_query.GetById(), obj);
        }

        public virtual int Add(object obj)
        {
            return _context.ExecuteScalar<int>(_query.Add(), obj);
        }

        public virtual bool BulkCopy(DataTable dt, string tableName)
        {
            return _context.BulkCopy(dt, tableName);
        }
        #endregion
    }
}
