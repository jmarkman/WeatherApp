using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WeatherAPI;

namespace WeatherApp.ViewModel
{
    public class WeatherViewModel
    {
        private WeatherClient client = new WeatherClient("aaa");
        public int ZipCode { get; set; }
        public ICommand GetWeatherCommand { get; }
        public ReadOnlyObservableCollection<Weather> WeatherData { get; }

        public WeatherViewModel()
        {
            
        }

        public void GetWeather(int zipCode)
        {
            WeatherData = client.GetWeatherDataAsync(zipCode).Result;
        }
        
    }
}
