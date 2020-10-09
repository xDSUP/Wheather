using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecstopApplication.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        public string Name { get; set; }

        public List<WeatherForecast> WeatherForecasts { get; set; }

        public override string ToString() => Name;
    }
}
