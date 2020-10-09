using System;
using System.Collections.Generic;
using System.Text;

namespace DecstopApplication.Models
{
    class DataCities
    {
        public List<City> Cities { get; set; } 

        private DataCities()
        {
        }

        private static DataCities _instance;

        public static DataCities Instance()
        {
            if (_instance == null)
                _instance = new DataCities();
            return _instance;
        }
    }
}
