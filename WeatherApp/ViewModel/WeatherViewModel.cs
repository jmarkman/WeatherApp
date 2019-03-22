using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WeatherApp.Commands;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    public class WeatherViewModel
    {
        //private WeatherClient client = new WeatherClient("aaa");

        public int ZipCode { get; set; }
        public ICommand GetWeatherCommand { get; }
        //public ReadOnlyObservableCollection<Model.Weather> WeatherData { get; }

        public Model.Weather Weather { get; }
        public bool CanUpdate
        {
            get
            {
                if (Weather == null)
                {
                    return false;
                }
                return !string.IsNullOrWhiteSpace(Weather.WeatherCondition);
            }
        }

        public WeatherViewModel()
        {
            Weather = new Model.Weather("Rain");
            GetWeatherCommand = new GetWeatherCommand(this);
        }

        public void GetWeather()
        {
            //client.GetWeatherDataAsync(zipCode).Result;
            MessageBox.Show("Hello World");
        }

    }
}
