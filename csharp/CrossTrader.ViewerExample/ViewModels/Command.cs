using System;
using System.Windows.Input;

namespace CrossTrader.ViewerExample.ViewModels
{
    public sealed class Command : ICommand
    {
        private readonly Action _Execute;

        public Command(Action execute)
            => _Execute = execute;

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        public bool CanExecute(object parameter)
            => true;

        public void Execute(object parameter)
            => _Execute();

        public static Command Create(Action execute)
            => new Command(execute);

        public static Command<T> Create<T>(Action<T> execute)
            => new Command<T>(execute);
    }
    public sealed class Command<T> : ICommand
    {
        private readonly Action<T> _Execute;

        public Command(Action<T> execute)
            => _Execute = execute;

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        public bool CanExecute(object parameter)
            => true;

        public void Execute(object parameter)
            => _Execute((T)parameter);
    }
}