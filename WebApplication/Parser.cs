using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using WebApplication.Models;

namespace WebApplication
{
    public class Parser
    {
        internal AppDb Db { get; set; }

        // ссылка на сайт, который будем парсить
        private static String url = "https://pogoda33.ru/";

        public Parser() {}

        internal Parser(AppDb db)
        {
            Db = db;
        }

        // когда мы уже знаем адрес нужной страницы
        public WeatherInHour[] findWheatherOnDateAsync(String cityName, DateTime date)
        {
            String result;
            //TODO: убрать хардкод даты
            var currentUrl = url + $"погода-{cityName}/день/4-октября";
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(currentUrl);
            
            var weatherDoc = doc.DocumentNode.SelectSingleNode("//div[@class='days d-none d-lg-block']");
            WeatherInHour[] weathers = new WeatherInHour[4];
            for (int i = 0; i < weathers.Length; i++)
                weathers[i] = new WeatherInHour();
            if (weatherDoc != null)
            {
                var sky = weatherDoc.SelectNodes("//div[@class='col-md-1 sky-icon mtt']");
			if (sky != null)
                    for (int i = 0; i < weathers.Length; i++)
                        weathers[i].Sky = sky[i*2+1].Attributes["data-mtt"].Value;

            var temperature = weatherDoc.SelectNodes("//div[@class='col-md-1 temperature']");
			if(temperature != null)
				for (int i = 0; i < weathers.Length; i++){
                    String t = temperature[i * 2 + 1].InnerText;
                    weathers[i].Temperature = int.Parse(t.Substring(0,t.Length-2));
				}
			var precipitation = weatherDoc.SelectNodes("//div[@class='col-md-1 precipitation']");
			if(precipitation != null)
				for (int i = 0; i < weathers.Length; i++){
					String t = precipitation[i * 2 + 1].InnerText;
                    weathers[i].Precipitation = float.Parse(t.Substring(0,t.Length-2));
				}
			
			var pressure = weatherDoc.SelectNodes("//div[@class='col-md-1 pressure']");
			if(pressure != null)
				for (int i = 0; i < weathers.Length; i++){
					String t = pressure[i * 2 + 1].InnerText;
                    weathers[i].Pressure = int.Parse(t.Substring(0,t.Length-4));
				}
			
			// простите за это
			var speed = weatherDoc.SelectNodes("//div[@class='col-md-1 wind-speed']");
			if(speed != null)
				for (int i = 0; i < weathers.Length; i++){
					String t = speed[i * 2 + 1].InnerText;
                    weathers[i].Speed = int.Parse(t.Substring(0,t.Length-4));
					// направление тоже попало сюда, начиная с 9 элемента
					t = speed[8+i * 2 + 1].InnerText;
                    weathers[i].Wind = t.Substring(1);
				}
			var humidiy = weatherDoc.SelectNodes("//div[@class='col-md-1 dew-point']");
			if(humidiy != null)
				for (int i = 0; i < weathers.Length; i++){
					String t = humidiy[i * 2 + 1].InnerText;
                    weathers[i].Humidiy = int.Parse(t.Substring(0,t.Length-1));
				}
            }

            return weathers;
        }

    }
}
