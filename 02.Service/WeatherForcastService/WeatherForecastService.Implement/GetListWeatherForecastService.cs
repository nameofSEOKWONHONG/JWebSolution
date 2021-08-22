using System.Collections.Generic;
using System.Threading.Tasks;
using Entity;
using JServiceStack.Database;
using JServiceStack.Service;
using Microsoft.Data.SqlClient;
using WeatherForecastService.Contract.Interfaces;
using RepoDb;

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

        public override async Task ExecuteAsync()
        {
            this.Result = await JDatabaseResolver.Resolve<SqlConnection>()
                .ExecuteAsync(async db => await db.QueryAllAsync<WEATHER_FORECAST>());
            //var results = new List<WEATHER_FORECAST>();
            // return await Task.Run(() =>
            // {
            //     var rng = new Random();
            //     results.AddRange(Enumerable.Range(1, 5).Select(index => new WEATHER_FORECAST
            //         {
            //             ID = index,
            //             DATE = DateTime.Now.AddDays(index),
            //             TEMP_C = rng.Next(-20, 55),
            //             SUMMARY = Summaries[rng.Next(Summaries.Length)]
            //         })
            //         .ToArray());
            //     return results;
            // });
        }

        public override Task ExecutedAsync()
        {
            return base.ExecutedAsync();
        }
    }
}