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
    public class WeatherViewModel : INotifyPropertyChanged
    {
        // This would have a key as the param if I was running it on my end
        private WeatherClient client = new WeatherClient("aaa");
        private int _zipCode;
        private WeatherModel _weatherModel;

        public event PropertyChangedEventHandler PropertyChanged;

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
                OnPropertyChanged("ZipCode");
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
                OnPropertyChanged("WeatherModel");
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
            GetWeatherCommand = new RelayCommand(GetWeather);
        }

        public void GetWeather()
        {
            var weatherData = client.GetWeatherDataAsync(ZipCode).Result;
            Weather = new Model.WeatherModel(weatherData.Weather[0].WeatherCondition);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
