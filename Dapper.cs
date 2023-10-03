using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DapperDatabase
{
    public class Dapper : IDapper
    {
        private readonly IDbConnection _dbConnection;

        public Dapper()
        {
            _dbConnection = new SqlConnection();
        }
        public Dapper(string connectType)
        {
            switch (connectType)
            {
                case "member":
                    _dbConnection = new SqlConnection(ConfigurationManager.AppSettings["conString"]);
                    break;
                case "server":
                    _dbConnection = new SqlConnection(ConfigurationManager.AppSettings["conServer"]);
                    break;
                default:
                    _dbConnection = new SqlConnection(ConfigurationManager.AppSettings["conServer"]);
                    break;
            }
        }
        private void EnsureConnectionOpen()
        {
            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open();
            }
        }
        public IEnumerable<T> Query<T>(string sql, object parameters = null)
        {
            EnsureConnectionOpen();
            try
            {
                return _dbConnection.Query<T>(sql, parameters);
            }
            finally
            {
                _dbConnection.Close();
            }
        }

        public int Execute(string sql, object parameters = null)
        {
            EnsureConnectionOpen();
            try
            {
                return _dbConnection.Execute(sql, parameters);
            }
            finally
            {
                _dbConnection.Close();
            }
        }

        public T Get<T>(int id)
        {
            // Implement the Get method to retrieve an entity by its ID
            throw new NotImplementedException();
        }

        public bool Insert<T>(T entity)
        {
            // Implement the Insert method to add a new entity
            throw new NotImplementedException();
        }

        public bool Update<T>(T entity)
        {
            // Implement the Update method to modify an existing entity
            throw new NotImplementedException();
        }

        public bool Delete<T>(int id)
        {
            // Implement the Delete method to remove an entity by its ID
            throw new NotImplementedException();
        }

        // Implement IDisposable to close the connection when the repository is disposed
        public void Dispose()
        {
            _dbConnection.Dispose();
        }
    }
}