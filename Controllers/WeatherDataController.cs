using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularCodingTest.Controllers
{
    [Route("api/[controller]/[action]")]
    public class WeatherDataController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WeatherDataController(ApplicationDbContext context)
        {
            _context = context;
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<ActionResult> Forecasts()
        {
            var rng = new Random();
            var results = await _context.Forecasts.Select(x => new
            {
                x.Date,
                x.TemperatureC,
                x.TemperatureF,
                Summary = Summaries[rng.Next(0, Summaries.Length)]//TODO Get from new summary code
            }).OrderByDescending(x => x.Date).Take(30).ToListAsync();
            return Ok(results);
        }
    }
}
