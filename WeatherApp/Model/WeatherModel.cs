using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI;

namespace WeatherApp.Model
{
    public class WeatherModel : INotifyPropertyChanged
    {
        private string _city;
        private string _weatherCondition;
        private string _temperature;
        private string _maxTemp;
        private string _minTemp;
        private string _humidity;
        private string _cloudCoverage;

        #region OnPropertyChangedVariables

        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        public string WeatherCondition
        {
            get
            {
                return _weatherCondition;
            }
            set
            {
                _weatherCondition = value;
                OnPropertyChanged(nameof(WeatherCondition));
            }
        }

        public string Temperature
        {
            get
            {
                return _temperature;
            }
            set
            {
                _temperature = value;
                OnPropertyChanged(nameof(Temperature));
            }
        }

        public string MaximumTemperature
        {
            get
            {
                return _maxTemp;
            }
            set
            {
                _maxTemp = value;
                OnPropertyChanged(nameof(MaximumTemperature));
            }
        }

        public string MinimumTemperature
        {
            get
            {
                return _minTemp;
            }
            set
            {
                _minTemp = value;
                OnPropertyChanged(nameof(MinimumTemperature));
            }
        }

        public string Humidity
        {
            get
            {
                return _humidity;
            }
            set
            {
                _humidity = value;
                OnPropertyChanged(nameof(Humidity));
            }
        }

        public string CloudCoverage
        {
            get
            {
                return _cloudCoverage;
            }
            set
            {
                _cloudCoverage = value;
                OnPropertyChanged(nameof(CloudCoverage));
            }
        }

        #endregion

        public WeatherModel(WeatherData weatherData)
        {
            WeatherCondition = weatherData.Weather[0].WeatherCondition;
            City = weatherData.CityName;
            Temperature = weatherData.TemperatureAndPressure.Temperature.ToString();
            MaximumTemperature = weatherData.TemperatureAndPressure.MaximumTemperature.ToString();
            MinimumTemperature = weatherData.TemperatureAndPressure.MinimumTemperature.ToString();
            Humidity = weatherData.TemperatureAndPressure.Humidity.ToString();
            CloudCoverage = weatherData.CloudInfo.CloudCoveragePercent.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
