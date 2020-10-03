using System;

namespace WebApplication.Models
{
   
    // погода в городе в день ... по 4-м часам (утром, днем, вечером, ночью)
    public class WeatherForecast
    {
        public int IdCity { get; set; }

        public DateTime Date { get; set; }

        public System.Collections.Generic.List<WeatherInHour> WeatherInHours { get;set; }

        
    }
}
