using MySql.Data.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Models
{
    public class WeatherForecastContext : DbContext
    {

        public DbSet<City> Citys { get; set; }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public WeatherForecastContext()
        {
        }

        public WeatherForecastContext(DbContextOptionsBuilder optionsBuilder):base(optionsBuilder.Options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;UserId=root;Password=xD_HOHOHO32;database=weather;charset=utf8;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(t => t.WeatherForecasts)
                .WithOne();
        }
    }
}

