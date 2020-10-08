using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApplication.Models;

namespace WebApplication
{
    public class Parser : IHostedService, IDisposable
    {
        internal WeatherForecastContext _context { get; set; }
        private readonly ILogger<Parser> _logger;
        private Timer _timer;

        // ссылка на сайт, который будем парсить
        private const String URL = "https://world-weather.ru/pogoda/";
        // регион для которого смотрим города
        private const String REGION = "russia/bryansk_oblast/";

        public Parser(ILogger<Parser> logger) {
            _logger = logger;
        }

        public void UpdateAllCityes()
        {
            _context = new WeatherForecastContext();
            var currentUrl = URL + REGION;
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(currentUrl);
            //_logger.LogInformation("КОдировка" + doc.Encoding);
            var TownElements = doc.DocumentNode.SelectNodes("//li[@class='city-block']");
            foreach (var TownElement in TownElements)
            {
                var temp = TownElement.SelectSingleNode("a");
                String cityName = temp.InnerText;
                String link = temp.Attributes["href"].Value;

                City city = _context.Citys
                    .Where(t => t.Name == cityName)
                    .Include(t => t.WeatherForecasts)
                    .FirstOrDefault();

                _logger.LogInformation($"Get weather by {cityName}");
                if (city == null)
                {
                    city = new City();
                    city.Name = cityName;
                    city.WeatherForecasts = new List<WeatherForecast>();
                    setWheatherForecast(link, city);
                    _context.Citys.Add(city);
                }
                else
                {
                    city.WeatherForecasts.Clear();
                    _context.SaveChanges();
                    setWheatherForecast(link, city);
                }
                _context.SaveChanges();
            }
        }

        private void DoWork(object obj)
        {
            _logger.LogInformation("Start update weather");
            UpdateAllCityes();
        }

            // когда мы уже знаем адрес нужной страницы
        private void setWheatherForecast(String link, City city)
        {
            var currentUrl = "https:" + link + $"10days/";
            HtmlWeb web = new HtmlWeb();

            var docWeather = web.Load(currentUrl);
            var weatherElements = docWeather.DocumentNode.SelectNodes("//div[@class='weather-short']");
            // небольшой костыль, тк с сайта взять дату трудно
            DateTime time = DateTime.Now;
            foreach (var weatherOnDay in weatherElements)
            {
                //String date = weatherOnDay.SelectSingleNode("div[@class='dates short-d']").InnerText;

                foreach (var weatherOnPartOfDay in weatherOnDay.SelectNodes("table/tr"))
                {
                    var weatherForecast = new WeatherForecast();

                    //TODO: дату в каждый день и вроде все!
                    weatherForecast.Date = time;

                    weatherForecast.PartOfDay = weatherOnPartOfDay.SelectSingleNode("td[@class='weather-day']").InnerText;

                    String temp = weatherOnPartOfDay.SelectSingleNode("td[@class='weather-temperature']").InnerText;
                    weatherForecast.Temperature = int.Parse(temp.Substring(0, temp.Length-1));

                    weatherForecast.Sky = weatherOnPartOfDay.SelectSingleNode("td[@class='weather-temperature']/div").Attributes["title"].Value;

                    temp = weatherOnPartOfDay.SelectSingleNode("td[@class='weather-probability']").InnerText;
                    weatherForecast.Precipitation = int.Parse(temp.Substring(0, temp.Length - 1));

                    weatherForecast.Pressure = int.Parse(weatherOnPartOfDay.SelectSingleNode("td[@class='weather-pressure']").InnerText);

                    temp = weatherOnPartOfDay.SelectSingleNode("td[@class='weather-humidity']").InnerText;
                    weatherForecast.Humidity = int.Parse(temp.Substring(0, temp.Length - 1));

                    weatherForecast.Speed = float.Parse(weatherOnPartOfDay.SelectSingleNode("td[@class='weather-wind']").InnerText.Replace('.', ','));

                    weatherForecast.Wind = weatherOnPartOfDay.SelectSingleNode("td[@class='weather-wind']/span").Attributes["title"].Value;

                    weatherForecast.CityId = city.CityId;

                    city.WeatherForecasts.Add(weatherForecast);

                    //Console.WriteLine("температура: " + weatherOnPartOfDay.SelectSingleNode("td[@class='weather-temperature']").InnerText + "\n");
                }
                time = time.AddDays(1);
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(
                DoWork, 
                null, 
                TimeSpan.Zero,
                TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}

