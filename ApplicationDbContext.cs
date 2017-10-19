using System;
using System.Linq;
using System.Threading.Tasks;
using AngularCodingTest.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularCodingTest
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            InitForecasts();
        }
        public virtual DbSet<WeatherForecast> Forecasts { get; set; }


        /// <summary>
        /// Hacky init command to put 5 temperatures in the database
        /// Good enough for the coding test since we're not using a real database
        /// </summary>
        private void InitForecasts()
        {
            if (Forecasts.Any()) return;

            var rng = new Random();
            var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(-index).AddMinutes(rng.Next(-1000, 1000)),
                TemperatureC = rng.Next(-20, 55),
            });

            Forecasts.AddRange(forecasts);
            SaveChanges();
        }
    }
}