using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.ViewModel
{
    public class CurrentWeatherViewModel : BaseViewModel
    {
        private string _weatherCondition;
        public WeatherViewModel WeatherViewModel { get; set; }
        
        public string WeatherCondition
        {
            get
            {
                return _weatherCondition;
            }
            set
            {
                _weatherCondition = value;
                OnPropertyChanged();
            }
        }

        public CurrentWeatherViewModel()
        {
            WeatherViewModel = new WeatherViewModel();
        }


    }
}
