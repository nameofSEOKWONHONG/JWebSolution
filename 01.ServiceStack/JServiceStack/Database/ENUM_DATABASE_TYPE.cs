using eXtensionSharp;

namespace JServiceStack.Database
{
    internal class ENUM_DATABASE_TYPE : XEnumBase<ENUM_DATABASE_TYPE>
    {
        public static readonly ENUM_DATABASE_TYPE MSSQL = Define("MSSQL");
        public static readonly ENUM_DATABASE_TYPE MYSQL = Define("MYSQL");
        public static readonly ENUM_DATABASE_TYPE POSTGRESQL = Define("POSTGRESQL");
    }

    internal class ENUM_NOSQL_DATABASE_TYPE : XEnumBase<ENUM_NOSQL_DATABASE_TYPE>
    {
        public static readonly ENUM_NOSQL_DATABASE_TYPE REDIS = Define("REDIS");
        public static readonly ENUM_NOSQL_DATABASE_TYPE MONGODB = Define("MONGODB");
    }
}