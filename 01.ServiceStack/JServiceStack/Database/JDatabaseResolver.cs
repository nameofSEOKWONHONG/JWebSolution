using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Npgsql;

namespace JServiceStack.Database
{
    public class JDatabaseResolver
    {
        public static JDatabaseExecutor Resolve<TDbConnection>()
            where TDbConnection : IDbConnection
        {
            IDbConnection connection = null;
            if (typeof(TDbConnection) == typeof(SqlConnection))
            {
                RepoDb.SqlServerBootstrap.Initialize();
                connection = JDatabaseInfo.Instance.GetConnection(ENUM_DATABASE_TYPE.MSSQL);
            }
            else if (typeof(TDbConnection) == typeof(NpgsqlConnection))
            {
                RepoDb.PostgreSqlBootstrap.Initialize();
                connection = JDatabaseInfo.Instance.GetConnection(ENUM_DATABASE_TYPE.POSTGRESQL);
            }
            else
                throw new NotImplementedException();

            return new JDatabaseExecutor(connection);
        }
    }
}