using System;
using System.Collections.Generic;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using WebApiBase;

namespace WeatherForcastService.Application.Controllers
{
    public class WeatherForecastController : JContollerBase
    {
        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IMemoryCache memoryCache) : base(logger, memoryCache)
        {
        }

        [HttpGet]
        public IEnumerable<WEATHER_FORECAST> Gets()
        {
            IEnumerable<WEATHER_FORECAST> result = null;

            if (MemoryCache.TryGetValue("gets", out result)) return result;

            result = WeatherForecastService.Implement.WeatherForecastService.Gets();
            var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(10));
            cacheOptions.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);
            MemoryCache.Set("gets", result, cacheOptions);
            return result;
        }
    }
}