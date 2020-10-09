using DecstopApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DesktopApplication
{
    class WeatherApi
    {
        private const String url = "https://localhost:5001";
        private static JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        /// <summary>
        /// получает все города с апи
        /// </summary>
        /// <returns></returns>
        public static List<City> GetCities()
        {
            List<City> cities = new List<City>();
            WebRequest request = WebRequest.Create(url + "/api/weatherforecast/");
            WebResponse response = request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                String responseText = reader.ReadToEnd();
                
                cities = JsonSerializer.Deserialize<List<City>>(responseText, options);
            }
            response.Close();
            return cities;
        }

        /// <summary>
        /// получает погоду для конкретного города
        /// </summary>
        /// <param name="id">ид города для которого получаем</param>
        /// <returns></returns>
        public static void GetCityWithWeather(City city)
        {
            City tempCity;
            WebRequest request = WebRequest.Create(url +$"/api/weatherforecast/{city.CityId}"  );
            var response = request.GetResponse();
            using(StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                String responseText = reader.ReadToEnd();
                tempCity = JsonSerializer.Deserialize<City>(responseText, options);
                city.WeatherForecasts = tempCity.WeatherForecasts;
            }
            response.Close();
        }
    }
}
