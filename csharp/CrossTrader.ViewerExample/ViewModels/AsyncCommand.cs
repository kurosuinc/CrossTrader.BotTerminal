using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CrossTrader.ViewerExample.ViewModels
{
    public sealed class AsyncCommand : ICommand
    {
        private readonly Func<Task> _Execute;

        public AsyncCommand(Func<Task> execute)
            => _Execute = execute;

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        public bool CanExecute(object parameter)
            => true;

        public async void Execute(object parameter)
            => await _Execute();

        public static AsyncCommand Create(Func<Task> execute)
            => new AsyncCommand(execute);

        public static AsyncCommand<T> Create<T>(Func<T, Task> execute)
            => new AsyncCommand<T>(execute);
    }
    public sealed class AsyncCommand<T> : ICommand
    {
        private readonly Func<T, Task> _Execute;

        public AsyncCommand(Func<T, Task> execute)
            => _Execute = execute;

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        public bool CanExecute(object parameter)
            => true;

        public async void Execute(object parameter)
            => await _Execute((T)parameter);
    }
}
