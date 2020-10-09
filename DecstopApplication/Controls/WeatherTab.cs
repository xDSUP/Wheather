using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DesktopApplication
{
    public partial class WeatherTab : UserControl
    {
        public WeatherTab(String partOfDay, String cloudness, int temperature,
            int pressure, int windSpeed, String wind, int Humidity)
        {
            InitializeComponent();
            labelPartOfDay.Text = partOfDay;
            labelCloudiness.Text = cloudness;
            labelHumidity.Text = Humidity.ToString() + "%";
            labelPressure.Text = pressure.ToString() + " мм";
            labelTemperature.Text = temperature.ToString();
            labelWind.Text = wind;
            labelWindSpeed.Text = windSpeed.ToString() + " м/с";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
