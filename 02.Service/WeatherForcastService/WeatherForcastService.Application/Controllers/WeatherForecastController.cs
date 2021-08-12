using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entity;
using JServiceStack.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using WeatherForecastService.Contract.Interfaces;

namespace WeatherForcastService.Application.Controllers
{
    public class WeatherForecastController : JContollerBase
    {
        private readonly IGetListWeatherForecastService _getListWeatherForecastService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IMemoryCache memoryCache, IGetListWeatherForecastService getListWeatherForecastService) : base(logger, memoryCache)
        {
            this._getListWeatherForecastService = getListWeatherForecastService;
        }

        [HttpGet]
        public async Task<IEnumerable<WEATHER_FORECAST>> Gets()
        {
            IEnumerable<WEATHER_FORECAST> result = null;

            if (MemoryCache.TryGetValue("gets", out result)) return result;

            result = await ExecuteSerivceAsync<IGetListWeatherForecastService, int, IEnumerable<WEATHER_FORECAST>>(this._getListWeatherForecastService, 0);
            
            var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(10));
            cacheOptions.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);
            MemoryCache.Set("gets", result, cacheOptions);
            return result;
        }
    }
}