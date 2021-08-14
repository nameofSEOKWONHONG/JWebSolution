using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JServiceStack.Web;
using McMaster.NETCore.Plugins;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace JWebApiServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            var mvcBuilder = services.AddControllers();

            var loaders = GetPluginLoaders(mvcBuilder);
            ConfigureServices(services, loaders);

            // create plugin loaders
            // foreach (var dir in Directory.GetDirectories(Path.Combine(AppContext.BaseDirectory, "plugins")))
            // {
            //     var pluginFile = Path.Combine(dir, Path.GetFileName(dir) + ".dll");
            //     // The AddPluginFromAssemblyFile method comes from McMaster.NETCore.Plugins.Mvc
            //     mvcBuilder.AddPluginFromAssemblyFile(pluginFile);
            // }
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo {Title = "JWebApiServer", Version = "v1"});
            });
            
            //services.AddLogging(config => { config.AddConsole(); });
            services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "JWebApiServer v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private static List<PluginLoader> GetPluginLoaders(IMvcBuilder mvcBuilder)
        {
            var loaders = new List<PluginLoader>();

            // create plugin loaders
            var pluginsDir = Path.Combine(AppContext.BaseDirectory, "plugins");
            foreach (var dir in Directory.GetDirectories(pluginsDir))
            {
                var dirName = Path.GetFileName(dir);
                var pluginDll = Path.Combine(dir, dirName + ".dll");
                if (File.Exists(pluginDll))
                {
                    var loader = PluginLoader.CreateFromAssemblyFile(
                        pluginDll,
                        new[] {typeof(IPluginFactory), typeof(IServiceCollection)});
                    loaders.Add(loader);
                    mvcBuilder.AddPluginLoader(loader);
                }
            }

            return loaders;
        }

        private static void ConfigureServices(IServiceCollection services, List<PluginLoader> loaders)
        {
            // Create an instance of plugin types
            foreach (var loader in loaders)
            foreach (var pluginType in loader
                .LoadDefaultAssembly()
                .GetTypes()
                .Where(t => typeof(IPluginFactory).IsAssignableFrom(t) && !t.IsAbstract))
            {
                // This assumes the implementation of IPluginFactory has a parameterless constructor
                var plugin = Activator.CreateInstance(pluginType) as IPluginFactory;

                plugin?.Configure(services);
            }
        }
    }
}