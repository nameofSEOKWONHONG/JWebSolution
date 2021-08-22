using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using eXtensionSharp;
using JServiceStack.Database;

namespace ConfigBuilder
{
    public class DatabaseConfigWriter
    {
        internal static void WriteSettingFile(string filePath) { 
            var key = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).xSubstring(0, 16);
            var chipper = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).xSubstring(0, 16);
            var configProvider = new JDatabaseConfigProvider();
            configProvider.MSSQL =
                "Data Source=172.19.1.56,1433;Initial Catalog=TEST;User ID=sa;Password=1q2w3e4r!Q@W#E$R".xToEncAES256(
                    key, chipper, CipherMode.CBC, PaddingMode.PKCS7);
            configProvider.POSTGRESQL = "Server=192.168.55.204;Port=5432;Database=testdb;User Id=seokwon;Password=1q2w3e4r!Q@W#E$R;".xToEncAES256(
                key, chipper, CipherMode.CBC, PaddingMode.PKCS7);
            configProvider.KEY = key;
            configProvider.CHIPER = chipper;

            var config = new JDatabaseConfig
            {
                ConfigProvider = configProvider
            };
            var json = config.xToJson();

            var configPath = filePath;
            configPath.xFileCreateAll();
            Thread.Sleep(1000);

            using var fs = File.Open(configPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            using var sw = new StreamWriter(fs);
            sw.Write(json);
            sw.Close();
            fs.Close();
        }
    }
}