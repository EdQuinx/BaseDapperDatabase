using System;
using System.Collections.Generic;

namespace DapperDatabase
{
    public interface IDapper : IDisposable
    {
        IEnumerable<T> Query<T>(string sql, object parameters = null);
        int Execute(string sql, object parameters = null);
        T Get<T>(int id);
        bool Insert<T>(T entity);
        bool Update<T>(T entity);
        bool Delete<T>(int id);
    }
}