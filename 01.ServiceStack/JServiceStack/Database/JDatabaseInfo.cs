using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Npgsql;
using RepoDb;

namespace JServiceStack.Database
{
    internal class JDatabaseInfo
    {
        #region [1st class variable]

        private readonly Dictionary<string, Func<string, IDbConnection>> _connectionMaps = new()
        {
            {
                ENUM_RDB_TYPE.MSSQL.ToString(), connectionString =>
                {
                    //no more use System.Data.SqlClient.SqlConnection
                    //replace Microsoft.Data.SqlClient.SqlConnection
                    SqlServerBootstrap.Initialize();
                    return new SqlConnection(JDatabaseProvider.Instance.MSSQL);
                }
            },
            {
                ENUM_RDB_TYPE.POSTGRESQL.ToString(), connectionString =>
                {
                    PostgreSqlBootstrap.Initialize();
                    return new NpgsqlConnection(JDatabaseProvider.Instance.POSTGRESQL);
                }
            },
        };

        #endregion

        #region [ctor]

        #endregion

        public Dictionary<string, IDbConnection> Connections { get; } =
            new();

        public IDbConnection GetConnection(ENUM_RDB_TYPE dbType)
        {
            return _connectionMaps[dbType.ToString()].Invoke(dbType.ToString());
        }

        #region [lazy instance]

        private static readonly Lazy<JDatabaseInfo> _instance = new Lazy<JDatabaseInfo>(() => new JDatabaseInfo());

        public static JDatabaseInfo Instance => _instance.Value;

        #endregion
    }
}