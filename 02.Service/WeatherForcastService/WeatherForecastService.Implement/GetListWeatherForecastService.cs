using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using JServiceStack.Service;
using WeatherForecastService.Contract.Interfaces;

namespace WeatherForecastService.Implement
{
    public class GetListWeatherForecastService : ServiceExecutor<int, IEnumerable<WEATHER_FORECAST>>,
        IGetListWeatherForecastService
    {
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public override Task<bool> ExecutingAsync()
        {
            return base.ExecutingAsync();
        }

        public override async Task<IEnumerable<WEATHER_FORECAST>> ExecuteAsync()
        {
            var results = new List<WEATHER_FORECAST>();
            return await Task.Run(() =>
            {
                var rng = new Random();
                results.AddRange(Enumerable.Range(1, 5).Select(index => new WEATHER_FORECAST
                    {
                        ID = index,
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = rng.Next(-20, 55),
                        Summary = Summaries[rng.Next(Summaries.Length)]
                    })
                    .ToArray());
                return results;
            });
        }

        public override Task ExecutedAsync()
        {
            return base.ExecutedAsync();
        }
    }
}