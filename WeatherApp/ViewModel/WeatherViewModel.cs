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
using WeatherApp.Commands;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    public class WeatherViewModel
    {
        // This would have a key as the param if I was running it on my end
        private WeatherClient client = new WeatherClient("aaa");

        public ICommand GetWeatherCommand { get; }
        public int ZipCode { get; set; }
        public Model.Weather Weather { get; private set; }
        public bool CanUpdate
        {
            get
            {
                // first try logic for CanExecute, but this had the button automatically disabled

                //if (Weather == null)
                //{
                //    return false;
                //}
                //return !string.IsNullOrWhiteSpace(Weather.WeatherCondition);

                // second try logic for CanExecute, thought this would work because binding places a "0"
                // in the textbox automatically (though this isn't desired as a feature) and it would return
                // true until the user entered a code
                // return ZipCode == 0;

                return true;
            }
        }

        public WeatherViewModel()
        {
            GetWeatherCommand = new GetWeatherCommand(this, ZipCode);
        }

        public void GetWeather(int zipCode)
        {
            var weatherData = client.GetWeatherDataAsync(zipCode).Result;
            Weather = new Model.Weather(weatherData.Weather[0].WeatherCondition);
        }

    }
}
