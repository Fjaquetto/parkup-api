using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ParkUp.Domain.Interfaces
{
    public interface IContextDapper
    {
        bool BulkCopy(DataTable dt, string tableName);
        T ExecuteScalar<T>(string cmd, object parametros);
        T ExecuteObject<T>(string cmd, object param);
        T ParallelObject<T>(string cmd, object param);
        T ParallelScalar<T>(string cmd, object param);
        IEnumerable<T> ExecuteCollection<T>(string cmd, object param);
    }
}
