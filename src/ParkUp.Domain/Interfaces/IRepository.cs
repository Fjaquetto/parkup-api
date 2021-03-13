using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ParkUp.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        int Add(object obj);
        TEntity GetById(object obj);
        void Update(object obj);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetByFilter(object obj);
        void Remove(object obj);
        bool BulkCopy(DataTable dt, string tableName);
    }
}
