using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using eXtensionSharp;
using JServiceStack.Configs;

namespace ServiceBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO : add dotnet build command lines
            Build();
            //TODO : main application copy
            ApplicationCopy();
            //TODO : copy controller folder to "plugins"
            PluginCopy();
        }

        static void Build()
        {
            string[] paths = new[]
            {
                @"D:\workspace\JWebSolution\02.Service\AccountService\AccountService.Application",
                @"D:\workspace\JWebSolution\02.Service\WeatherForcastService\WeatherForcastService.Application"
            };

            paths.xForEach(item =>
            {
                Console.WriteLine(CommandOutput($"dotnet build", item));
            });
        }
        
        static string CommandOutput(string command,
            string workingDirectory = null)
        {
            try
            {
                ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + command);

                procStartInfo.RedirectStandardError = procStartInfo.RedirectStandardInput = procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                if (null != workingDirectory)
                {
                    procStartInfo.WorkingDirectory = workingDirectory;
                }

                Process proc = new Process();
                proc.StartInfo = procStartInfo;
                proc.Start();

                StringBuilder sb = new StringBuilder();
                proc.OutputDataReceived += delegate (object sender, DataReceivedEventArgs e)
                {
                    sb.AppendLine(e.Data);
                };
                proc.ErrorDataReceived += delegate (object sender, DataReceivedEventArgs e)
                {
                    sb.AppendLine(e.Data);
                };

                proc.BeginOutputReadLine();
                proc.BeginErrorReadLine();
                proc.WaitForExit();
                return sb.ToString();
            }
            catch (Exception objException)
            {
                return $"Error in command: {command}, {objException.Message}";
            }
        }

        static void ApplicationCopy()
        {
            
        }
        static void PluginCopy()
        {
            
            var paths = new Dictionary<string, string>()
            {
                {"AccountService", @"D:\workspace\JWebSolution\02.Service\AccountService\AccountService.Application\bin\Debug\net5.0"},
                {"WeatherForcastService", @"D:\workspace\JWebSolution\02.Service\WeatherForcastService\WeatherForcastService.Application\bin\Debug\net5.0"}
            };
            
            paths.xForEach(item =>
            {
                item.Value.xCopy(Path.Combine(JCONFIG_CONST.APP_PLUGIN_PATH, item.Key));
            });
        }
    }
    
    
}