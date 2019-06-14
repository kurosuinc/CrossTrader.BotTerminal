using System;
using System.Windows;

namespace CrossTrader.ViewerExample.Views
{
    public class CustomWindow : Window
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            (DataContext as IDisposable)?.Dispose();
        }
    }
}