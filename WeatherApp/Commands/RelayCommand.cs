using System;
using System.Windows.Input;

namespace WeatherApp.Commands
{
    public class RelayCommand : ICommand
    {
        //private Action _action;

        //public event EventHandler CanExecuteChanged = (sender, e) => { };


        //public RelayCommand(Action action)
        //{
        //    _action = action;
        //}

        //public bool CanExecute(object parameter)
        //{
        //    return true;
        //}

        //public void Execute(object parameter)
        //{
        //    _action();
        //}

        private readonly Predicate<object> _canExecute;
        private readonly Action _execute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action execute)
                       : this(execute, null)
        {
        }

        public RelayCommand(Action execute,
                       Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }


    }
}
