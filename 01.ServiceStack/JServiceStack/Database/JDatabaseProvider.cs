using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using eXtensionSharp;
using JServiceStack.Configs;
using Nito.AsyncEx;

namespace JServiceStack.Database
{
    internal class JDatabaseProvider
    {
        private static readonly Lazy<JDatabaseProvider> _dbProvider =
            new(() => new JDatabaseProvider());

        private static Dictionary<string, string> _providerMaps;
        private static readonly AsyncLock _mutex = new();

        public readonly string MSSQL = ProviderMaps[ENUM_DATABASE_TYPE.MSSQL.ToString()].xToDecAES256(
            JDatabaseKeyIVProvider.Instance.Key,
            JDatabaseKeyIVProvider.Instance.IV, CipherMode.CBC, PaddingMode.PKCS7, DeconvertCipherFormat.HEX);

        // public readonly string MYSQL = ProviderMaps[ENUM_DATABASE_TYPE.MYSQL.ToString()].xToDecAES256(
        //     JDatabaseKeyIVProvider.Instance.Key,
        //     JDatabaseKeyIVProvider.Instance.IV, CipherMode.CBC, PaddingMode.PKCS7, DeconvertCipherFormat.HEX);

        public readonly string POSTGRESQL = ProviderMaps[ENUM_DATABASE_TYPE.POSTGRESQL.ToString()].xToDecAES256(
            JDatabaseKeyIVProvider.Instance.Key,
            JDatabaseKeyIVProvider.Instance.IV, CipherMode.CBC, PaddingMode.PKCS7, DeconvertCipherFormat.HEX);

        public static JDatabaseProvider Instance => _dbProvider.Value;

        private static Dictionary<string, string> ProviderMaps
        {
            get
            {
                if (_providerMaps.xIsNull())
                    using (_mutex.Lock())
                    {
                        if (_providerMaps.xIsNull())
                        {
                            _providerMaps = new Dictionary<string, string>();
                            var configFile = JCONFIG_CONST.DB_CONFIG_PATH;
                            var configJson = configFile.xFileReadAllText();

                            var jconfig = configJson.xToEntity<JDatabaseConfig>();
                            _providerMaps.Add(ENUM_DATABASE_TYPE.MSSQL.xGetValue(), jconfig.ConfigProvider.MSSQL);
                            _providerMaps.Add(ENUM_DATABASE_TYPE.POSTGRESQL.xGetValue(),
                                jconfig.ConfigProvider.POSTGRESQL);
                        }
                    }

                return _providerMaps;
            }
        }
    }
}