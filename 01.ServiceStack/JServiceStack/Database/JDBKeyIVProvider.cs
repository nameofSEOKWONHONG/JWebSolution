using System;
using eXtensionSharp;
using JServiceStack.Configs;

namespace JServiceStack.Database
{
    internal class JDBKeyIVProvider
    {
        private static readonly Lazy<JDBKeyIVProvider> _instance =
            new(() => new JDBKeyIVProvider());

        public JDBKeyIVProvider()
        {
            var keyiv = Get();
            Key = keyiv.key;
            IV = keyiv.iv;
        }

        public string Key { get; }
        public string IV { get; }

        public static JDBKeyIVProvider Instance => _instance.Value;

        public (string key, string iv) Get()
        {
            //setting key & iv, read file or http request
            var configPath = JCONFIG_CONST.DB_CONFIG_PATH;
            var configJson = configPath.xFileReadAllText();
            var dbConfig = configJson.xToEntity<JDBConfig>();
            return new ValueTuple<string, string>(dbConfig.DBConfigProvider.KEY, dbConfig.DBConfigProvider.CHIPER);
        }
    }
}