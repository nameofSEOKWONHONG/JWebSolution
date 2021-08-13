using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.Data.SqlClient;
using Npgsql;
using RepoDb;
using RepoDb.Attributes;

namespace JServiceStack.Database
{
    public class JDatabaseResolver
    {
        public static JDatabaseExecutor Resolve<TDbConnection>(TransactionScopeOption option = TransactionScopeOption.Suppress)
            where TDbConnection : IDbConnection
        {
            IDbConnection connection = null;
            if (typeof(TDbConnection) == typeof(SqlConnection))
                connection = JDatabaseInfo.Instance.GetConnection(ENUM_DATABASE_TYPE.MSSQL);
            else if (typeof(TDbConnection) == typeof(NpgsqlConnection))
                connection = JDatabaseInfo.Instance.GetConnection(ENUM_DATABASE_TYPE.POSTGRESQL);
            else
                throw new NotImplementedException();

            var executor = new JDatabaseExecutor(connection, option);
            return executor;
        }
    }
    
    public class JDatabaseExecutor : IDisposable
    {
        private readonly IDbConnection _connection;
        private readonly TransactionScopeOption _options;
        public JDatabaseExecutor(IDbConnection connection, TransactionScopeOption option)
        {
            _connection = connection;
            _options = option;
        }

        public TResult Execute<TResult>(Func<IDbConnection, TResult> action)
        {
            TResult result;
            try
            {
                using var scope = new TransactionScope(_options);
                _connection.Open();
                result = action(_connection);
                scope.Complete();
            }
            finally
            {
                _connection.Close();
            }

            return result;
        }

        public async Task<TResult> ExecuteAsync<TResult>(Func<IDbConnection, Task<TResult>> action)
        {
            TResult result;
            
            try
            {
                using var scope = new TransactionScope(_options);
                _connection.Open();
                result = await action(_connection);
                scope.Complete();
            }
            finally
            {
                _connection.Close();
            }

            return result;
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}