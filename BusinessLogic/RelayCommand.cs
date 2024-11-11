using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BusinessLogic
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action _Execute { get; set; }

        public Func<bool> _CanExecute { get; set; }
        public RelayCommand(Action execute)
        {
            _Execute = execute;
        }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _Execute = execute;
            _CanExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _CanExecute == null ? true : _CanExecute();
        }

        public void Execute(object parameter)
        {
            _Execute();

        }
    }
}
