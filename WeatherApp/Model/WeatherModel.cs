using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public class WeatherModel : INotifyPropertyChanged
    {
        private string _weatherCondition;

        public string WeatherCondition
        {
            get
            {
                return _weatherCondition;
            }
            set
            {
                _weatherCondition = value;
                OnPropertyChanged("WeatherCondition");
            }
        }

        public WeatherModel(string weatherCondition)
        {
            WeatherCondition = weatherCondition;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
