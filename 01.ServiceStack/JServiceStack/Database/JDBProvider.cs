using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using eXtensionSharp;
using JServiceStack.Configs;
using Nito.AsyncEx;

namespace JServiceStack.Database
{
    public class JDBProvider
    {
        private static readonly Lazy<JDBProvider> _dbProvider =
            new(() => new JDBProvider());

        private static Dictionary<string, string> _providerMaps;
        private static readonly AsyncLock _mutex = new();

        public readonly string MSSQL = ProviderMaps[ENUM_RDB_TYPE.MSSQL.ToString()].xToDecAES256(
            JDBKeyIVProvider.Instance.Key,
            JDBKeyIVProvider.Instance.IV, CipherMode.CBC, PaddingMode.PKCS7, DeconvertCipherFormat.HEX);

        public readonly string MYSQL = ProviderMaps[ENUM_RDB_TYPE.MYSQL.ToString()].xToDecAES256(
            JDBKeyIVProvider.Instance.Key,
            JDBKeyIVProvider.Instance.IV, CipherMode.CBC, PaddingMode.PKCS7, DeconvertCipherFormat.HEX);

        public readonly string POSTGRESQL = ProviderMaps[ENUM_RDB_TYPE.POSTGRESQL.ToString()].xToDecAES256(
            JDBKeyIVProvider.Instance.Key,
            JDBKeyIVProvider.Instance.IV, CipherMode.CBC, PaddingMode.PKCS7, DeconvertCipherFormat.HEX);

        public static JDBProvider Instance => _dbProvider.Value;

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

                            var jconfig = configJson.xToEntity<JDBConfig>();
                            _providerMaps.Add(ENUM_RDB_TYPE.MSSQL.xSafe(), jconfig.DBConfigProvider.MSSQL);
                            _providerMaps.Add(ENUM_RDB_TYPE.MYSQL.xSafe(), jconfig.DBConfigProvider.MYSQL);
                            _providerMaps.Add(ENUM_RDB_TYPE.POSTGRESQL.xSafe(),
                                jconfig.DBConfigProvider.POSTGRESQL);
                        }
                    }

                return _providerMaps;
            }
        }
    }
}