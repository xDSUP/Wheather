using System;

namespace WebApplication.Models
{
   
    // ������ � ������ � ���� ... �� 4-� ����� (�����, ����, �������, �����)
    public class WeatherForecast
    {
        public int IdCity { get; set; }

        public DateTime Date { get; set; }

        public System.Collections.Generic.List<WeatherInHour> WeatherInHours { get;set; }

        
    }
}
