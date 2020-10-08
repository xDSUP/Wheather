using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace WebApplication.Models
{

    // ������ � ������ � ���� ... �� 4-� ����� (�����, ����, �������, �����)
    public class WeatherForecast
    {
        [Key]
        public int WeatherId { get; set; }

        public DateTime Date { get; set; }

        public string PartOfDay { get; set; }

        public int Temperature { get; set; }

        // ����������� �����
        public string Wind { get; set; }

        // �������� �����
        public float Speed { get; set; }

        // ��������
        public int Pressure { get; set; }

        // ���������
        public int Humidity { get; set; }

        // ����������� �������
        public int Precipitation { get; set; }

        // ����������
        public string Sky { get; set; }

        public int CityId { get; set; }
    }
}
