using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WeatherAPI;

namespace WeatherApp.ViewModel
{
    public class WeatherViewModel
    {
        private WeatherClient client = new WeatherClient("aaa");

        public WeatherData WeatherData { get; set; }

        public WeatherViewModel()
        {
            
        }

        public void GetWeather(int zipCode)
        {
            WeatherData = client.GetWeatherDataAsync(zipCode).Result;
        }
        
    }
}
