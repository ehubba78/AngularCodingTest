using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularCodingTest.Models;

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


        //private static string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        public async Task<ActionResult> Forecasts()
        {
            var rng = new Random();
            var results = await _context.Forecasts.Select(x => new
            {
                x.Date,
                x.TemperatureC,
                x.TemperatureF,
                //Summary = Summaries[rng.Next(0, Summaries.Length)]//TODO Get from new summary code
                Summary = Common.GlobalOperations.GetSummaryFromTemperature(x.TemperatureC)
            }).OrderByDescending(x => x.Date).Take(30).ToListAsync();
            return Ok(results);
        }

        public IActionResult GetCurrTemp()
        {
            var value = new CurrentTemperature
            {
                Message = Common.GlobalOperations.GetCurrentTemperature(null)
            };

            return Ok(value);
        }       
        [HttpGet("{temp}")]
        public IActionResult GetSummary(string temp)
        {
            
            var F = ((9.0 / 5.0) * Convert.ToInt32(temp)) + 32;

            var entry = new GenerateTempAddOn() {
                TemperatureC = Convert.ToInt32(temp),
                Summary = Common.GlobalOperations.GetSummaryFromTemperature(Convert.ToInt32(temp)),
                TemperatureF = Convert.ToInt32(F)
            };            

            return Ok(entry);
        }
    }
}
