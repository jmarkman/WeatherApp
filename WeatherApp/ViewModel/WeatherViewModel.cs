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
        private WeatherClient client = new WeatherClient("45fdf4a2d375aa1c3f5bef2b009eb11a");
        private int _zipCode;
        private WeatherModel _weatherModel;

        public ICommand GetWeatherCommand { get; }

        public int ZipCode
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
            GetWeatherCommand = new RelayCommand(GetWeatherAsync);
        }

        public async void GetWeatherAsync()
        {
            var weatherData = await client.GetWeatherDataAsync(ZipCode);
            Weather = new WeatherModel(weatherData);
        }
    }
}
