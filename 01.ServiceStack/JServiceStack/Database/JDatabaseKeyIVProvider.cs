using System;
using eXtensionSharp;
using JServiceStack.Configs;

namespace JServiceStack.Database
{
    internal class JDatabaseKeyIVProvider
    {
        private static readonly Lazy<JDatabaseKeyIVProvider> _instance =
            new(() => new JDatabaseKeyIVProvider());

        public JDatabaseKeyIVProvider()
        {
            var keyiv = Get();
            Key = keyiv.key;
            IV = keyiv.iv;
        }

        public string Key { get; }
        public string IV { get; }

        public static JDatabaseKeyIVProvider Instance => _instance.Value;

        public (string key, string iv) Get()
        {
            //setting key & iv, read file or http request
            var configPath = JCONFIG_CONST.DB_CONFIG_PATH;
            var configJson = configPath.xFileReadAllText();
            var dbConfig = configJson.xToEntity<JDatabaseConfig>();
            return new ValueTuple<string, string>(dbConfig.ConfigProvider.KEY, dbConfig.ConfigProvider.CHIPER);
        }
    }
}