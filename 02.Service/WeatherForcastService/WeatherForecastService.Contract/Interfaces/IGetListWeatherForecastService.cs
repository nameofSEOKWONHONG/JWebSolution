using System.Collections.Generic;
using Entity;
using JServiceStack.Service;

namespace WeatherForecastService.Contract.Interfaces
{
    public interface IGetListWeatherForecastService : IServiceExecutor<int, IEnumerable<WEATHER_FORECAST>> 
    {
        
    }
}