using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using eXtensionSharp;
using JServiceStack.Configs;

namespace ServiceBuilder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // 기존 어플리케이션 삭제
            if (Directory.Exists(JCONFIG_CONST.APP_PATH)) Directory.Delete(JCONFIG_CONST.APP_PATH, true);

            Build();

            ApplicationCopy();

            PluginCopy();
        }

        /// <summary>
        ///     프로젝트 빌드 커맨드
        /// </summary>
        private static void Build()
        {
            string[] paths =
            {
                @"D:\workspace\JWebSolution\02.Service\AccountService\AccountService.Application",
                @"D:\workspace\JWebSolution\02.Service\WeatherForcastService\WeatherForcastService.Application",
                @"D:\workspace\JWebSolution\03.Presentation\JWebApiServer"
            };

            paths.xForEach(item => { Console.WriteLine(CommandOutput("dotnet build", item)); });
        }

        /// <summary>
        ///     root 어플리케이션 copy
        /// </summary>
        private static void ApplicationCopy()
        {
            var paths = new Dictionary<string, string>
            {
                { "JWebApiApplication", @"D:\workspace\JWebSolution\03.Presentation\JWebApiServer\bin\Debug\net5.0" }
            };

            paths.xForEach(item => { item.Value.xCopy(JCONFIG_CONST.APP_PATH); });
        }

        /// <summary>
        ///     plugin 어플리케이션 copy
        /// </summary>
        private static void PluginCopy()
        {
            var paths = new Dictionary<string, string>
            {
                {
                    "AccountService.Application",
                    @"D:\workspace\JWebSolution\02.Service\AccountService\AccountService.Application\bin\Debug\net5.0"
                },
                {
                    "WeatherForcastService.Application",
                    @"D:\workspace\JWebSolution\02.Service\WeatherForcastService\WeatherForcastService.Application\bin\Debug\net5.0"
                }
            };

            paths.xForEach(item => { item.Value.xCopy(Path.Combine(JCONFIG_CONST.APP_PLUGIN_PATH, item.Key)); });
        }


        private static string CommandOutput(string command,
            string workingDirectory = null)
        {
            try
            {
                var procStartInfo = new ProcessStartInfo("cmd", "/c " + command);

                procStartInfo.RedirectStandardError =
                    procStartInfo.RedirectStandardInput = procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                if (null != workingDirectory) procStartInfo.WorkingDirectory = workingDirectory;

                var proc = new Process();
                proc.StartInfo = procStartInfo;
                proc.Start();

                var sb = new StringBuilder();
                proc.OutputDataReceived += delegate(object sender, DataReceivedEventArgs e) { sb.AppendLine(e.Data); };
                proc.ErrorDataReceived += delegate(object sender, DataReceivedEventArgs e) { sb.AppendLine(e.Data); };

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
    }
}