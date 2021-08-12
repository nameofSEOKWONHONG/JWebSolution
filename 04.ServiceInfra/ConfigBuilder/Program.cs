using System;
using JServiceStack.Configs;
using CS = System.Console;
namespace ConfigBuilder
{
    class Program
    {
        private static void Main(string[] args)
        {
            CS.WriteLine("write database config start");
            DatabaseConfigWriter.WriteSettingFile(JCONFIG_CONST.DB_CONFIG_PATH);
            CS.WriteLine("write database config end");
        }
    }
}