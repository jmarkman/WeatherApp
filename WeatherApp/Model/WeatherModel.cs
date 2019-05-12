using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
        private string _icon;

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

        public string Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
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
            Icon = weatherData.Weather[0].WeatherConditionIcon;

            FormatData();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Formats the incoming data from the OpenWeatherMap API to human-readable and relatable integers
        /// </summary>
        private void FormatData()
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            WeatherCondition = textInfo.ToTitleCase(WeatherCondition);

            Temperature = FormatTemperature(Temperature);
            MaximumTemperature = FormatTemperature(MaximumTemperature);
            MinimumTemperature = FormatTemperature(MinimumTemperature);
        }

        /// <summary>
        /// Wrapper for converting decimal temperatures to integer temperatures. Uses <see cref="Math.Ceiling(decimal)"/>, rounding up
        /// </summary>
        /// <param name="inputTemp">The temperature to convert from decimal to integer</param>
        /// <returns>The formatted temperature as a string</returns>
        private string FormatTemperature(string inputTemp)
        {
            var formattedTemperature = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(inputTemp)));

            return formattedTemperature.ToString();
        }
    }
}
