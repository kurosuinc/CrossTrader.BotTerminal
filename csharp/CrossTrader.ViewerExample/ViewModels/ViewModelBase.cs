using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CrossTrader.ViewerExample.ViewModels
{
    public abstract class ViewModelBase : IDisposable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName]string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetProperty<T>(ref T field, T value, Action onChanged = null, [CallerMemberName]string propertyName = null)
        {
            if (!((field as IEquatable<T>)?.Equals(value)
                ?? (value as IEquatable<T>)?.Equals(field)
                ?? Equals(field, value)))
            {
                field = value;
                RaisePropertyChanged(propertyName);
                onChanged?.Invoke();
                return true;
            }
            return false;
        }

        protected bool SetProperty<T>(ref T? field, T? value, Action onChanged = null, [CallerMemberName]string propertyName = null)
            where T : struct
        {
            if (!((field as IEquatable<T>)?.Equals(value) ?? Equals(field, value)))
            {
                field = value;
                RaisePropertyChanged(propertyName);
                onChanged?.Invoke();
                return true;
            }
            return false;
        }

        #region IDisposable Support

        protected bool IsDisposed { get; set; }

        protected virtual void Dispose(bool disposing)
            => IsDisposed = true;

        public void Dispose()
            => Dispose(true);

        #endregion IDisposable Support
    }
}