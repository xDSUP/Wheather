using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherForecastContext _context;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _context = new WeatherForecastContext();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCityes()
        {
            _logger.LogInformation("Get request");
            return await _context.Citys.ToListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<City>> GetCityes(int id)
        {
            _logger.LogInformation($"Get request by id : {id}");
            City cityWheatherForecasts = await _context.Citys.Include(t => t.WeatherForecasts).Where(t => t.CityId == id).FirstOrDefaultAsync();
            if(cityWheatherForecasts == null)
            {
                return NotFound();
            }
            return cityWheatherForecasts;
        }
    }
}
