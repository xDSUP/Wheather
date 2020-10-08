using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace WebApplication.Models
{

    // погода в городе в день ... по 4-м часам (утром, днем, вечером, ночью)
    public class WeatherForecast
    {
        [Key]
        public int WeatherId { get; set; }

        public DateTime Date { get; set; }

        public string PartOfDay { get; set; }

        public int Temperature { get; set; }

        // направление ветра
        public string Wind { get; set; }

        // скорость ветра
        public float Speed { get; set; }

        // давление
        public int Pressure { get; set; }

        // влажность
        public int Humidity { get; set; }

        // вероятность осадков
        public int Precipitation { get; set; }

        // облачность
        public string Sky { get; set; }

        public int CityId { get; set; }
    }
}
