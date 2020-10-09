using DecstopApplication.Models;
using DesktopApplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DecstopApplication
{
    public partial class WeatherApp : Form
    {
        private DataCities dataCities;

        public WeatherApp()
        {
            dataCities = DataCities.Instance();
            InitializeComponent();
            dateTimePicker.MinDate = DateTime.Now;
            dateTimePicker.MaxDate = DateTime.Now.AddDays(9);
        }

        public void updatePanelWeather()
        {
            var city = CityList.SelectedItem as City;
            // получаем прогноз погоды
            if(city == null)
            {
                return;
            }
            WeatherApi.GetCityWithWeather(city);

            panelWeather.Controls.Clear();
            foreach (var weatherForecast in city.WeatherForecasts.Where(t => t.Date.Date == dateTimePicker.Value.Date).Reverse())
            {
                WeatherTab weather = new WeatherTab(
                    weatherForecast.PartOfDay,
                    weatherForecast.Sky,
                    weatherForecast.Temperature,
                    weatherForecast.Pressure,
                    (int)weatherForecast.Speed,
                    weatherForecast.Wind,
                    weatherForecast.Humidity);
                panelWeather.Controls.Add(weather);
            }
        }

        private void butUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                dataCities.Cities = WeatherApi.GetCities();
                updateCitiesList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось обновить данные");
            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            updatePanelWeather();
        }

        private void updateCitiesList()
        {
            var sel = CityList.SelectedItem;
            CityList.Items.Clear();
            foreach (var city in dataCities.Cities)
            {
                CityList.Items.Add(city);
            }
            if(sel != null)
            {
                CityList.SelectedItem = sel;
                CityList.Text = sel.ToString();
            }
            
        }

        private void CityList_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatePanelWeather();
        }
    }
}
