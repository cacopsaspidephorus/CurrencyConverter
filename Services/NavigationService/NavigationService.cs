using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CurrencyConverter.Services
{
    internal class NavigationService : INavigationService
    {
        private readonly Frame _frame;

        public NavigationService()
        {
            _frame = Window.Current.Content as Frame;
        }

        public bool NavigateTo(Type source, object parameter = null)
        {
            return _frame.Navigate(source, parameter);
        }
    }
}
