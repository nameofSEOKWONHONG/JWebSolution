namespace JServiceStack.Database
{
    public class JDBConfig
    {
        public JDBConfigProvider DBConfigProvider { get; set; }
    }

    public class JDBConfigProvider
    {
        public string MSSQL { get; set; }
        public string MYSQL { get; set; }
        public string POSTGRESQL { get; set; }
        public string MONGODB { get; set; }
        public string REDIS { get; set; }
        public string SQLITE { get; set; }
        public string SQLITE_IN_MEMORY { get; set; }
        public string KEY { get; set; }
        public string CHIPER { get; set; }
    }
}