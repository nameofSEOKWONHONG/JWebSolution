using JServiceStack.WebApiBase;
using Microsoft.Extensions.DependencyInjection;

namespace WeatherForcastService.Application
{
    public class PluginConfiguration : IPluginFactory
    {
        public void Configure(IServiceCollection services)
        {
        }
    }
}