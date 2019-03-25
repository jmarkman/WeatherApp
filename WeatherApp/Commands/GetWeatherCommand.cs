using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.ViewModel;
using System.Windows.Input;

namespace WeatherApp.Commands
{
    internal class GetWeatherCommand : ICommand
    {
        private WeatherViewModel _viewModel;
        private int _zip;

        public GetWeatherCommand(WeatherViewModel viewModel, int zipCode)
        {
            _viewModel = viewModel;
            _zip = zipCode;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.CanUpdate;
        }

        public void Execute(object parameter)
        {
            _viewModel.GetWeather(_zip);
        }
    }
}
