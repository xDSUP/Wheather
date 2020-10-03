using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Models
{

    public class WeatherForecastContext : DbContext
    {
        public WeatherForecastContext(DbContextOptions<WeatherForecastContext> options)
            : base(options)
        {
        }

        public DbSet<WeatherForecast> WeatherForecast { get; set; }
    }
}
