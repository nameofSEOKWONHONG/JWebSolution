using eXtensionSharp;

namespace JServiceStack.Database
{
    public class ENUM_RDB_TYPE : XEnumBase<ENUM_RDB_TYPE>
    {
        public static readonly ENUM_RDB_TYPE MSSQL = Define("MSSQL");
        public static readonly ENUM_RDB_TYPE MYSQL = Define("MYSQL");
        public static readonly ENUM_RDB_TYPE POSTGRESQL = Define("POSTGRESQL");
    }

    public class ENUM_NOSQLDB_TYPE : XEnumBase<ENUM_NOSQLDB_TYPE>
    {
        public static readonly ENUM_NOSQLDB_TYPE REDIS = Define("REDIS");
        public static readonly ENUM_NOSQLDB_TYPE MONGODB = Define("MONGODB");
    }
}