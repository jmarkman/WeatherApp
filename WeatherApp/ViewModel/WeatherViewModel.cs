using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WeatherAPI;
using WeatherApp.Commands;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    public class WeatherViewModel : BaseViewModel
    {
        // This would have a key as the param if I was running it on my end
        // I already deleted this key pls no bully ;-;
        // TODO: where do I put a future API key and how would I access it?
        private WeatherClient client = new WeatherClient("45fdf4a2d375aa1c3f5bef2b009eb11a");
        private string _zipCode;
        private WeatherModel _weatherModel;

        public ICommand GetWeatherCommand { get; }

        /// <summary>
        /// The United States ZIP code of the area the user wants weather info from
        /// </summary>
        public string ZipCode
        {
            get
            {
                return _zipCode;
            }
            set
            {
                _zipCode = value;
                OnPropertyChanged(nameof(ZipCode));
            }
        }

        /// <summary>
        /// The weather data to be returned from the OpenWeatherMap API
        /// </summary>
        public WeatherModel Weather
        {
            get
            {
                return _weatherModel;
            }
            set
            {
                _weatherModel = value;
                OnPropertyChanged(nameof(Weather));
            }
        }
                
        public bool CanUpdate
        {
            get
            {
                return true;
            }
        }

        // ctor
        public WeatherViewModel()
        {
            GetWeatherCommand = new RelayCommand(GetWeatherAsync);
        }

        /// <summary>
        /// Calls <see cref="WeatherClient.GetWeatherDataAsync(string)"/> to get the current weather from the OpenWeatherMap API
        /// </summary>
        public async void GetWeatherAsync()
        {
            var weatherData = await client.GetWeatherDataAsync(ZipCode);
            Weather = new WeatherModel(weatherData);
        }
    }
}
