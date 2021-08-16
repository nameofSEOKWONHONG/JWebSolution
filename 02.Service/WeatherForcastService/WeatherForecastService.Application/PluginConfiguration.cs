using JServiceStack.Web;
using Microsoft.Extensions.DependencyInjection;
using WeatherForecastService.Contract.Interfaces;
using WeatherForecastService.Implement;

namespace WeatherForecastService.Application
{
    public class PluginConfiguration : IPluginFactory
    {
        public void Configure(IServiceCollection services)
        {
            services.AddSingleton<IGetListWeatherForecastService, GetListWeatherForecastService>();
        }
    }
}