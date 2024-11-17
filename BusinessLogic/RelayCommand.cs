using System;
using System.Windows.Input;

namespace BusinessLogic
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private event Action _execute;
        private event Func<bool> _canExecute;

        public RelayCommand(Action Execute)
        { _execute = Execute; }
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null ? true : _canExecute();
        public void Execute(object parameter) => _execute();
    }
}
