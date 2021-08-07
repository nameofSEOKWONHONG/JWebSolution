using System;
using System.Collections.Generic;
using System.Linq;
using Entity;

namespace WeatherForecastService.Implement
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public static IEnumerable<WEATHER_FORECAST> Gets()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WEATHER_FORECAST
                {
                    Id = index,
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }
    }
}