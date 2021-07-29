using CurrencyConverter.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CurrencyConverter.Pages
{
    public sealed partial class CurrencySelectorPage : Page
    {
        private readonly CurrencySelectorViewModel _currencySelectorViewModel;

        public CurrencySelectorPage()
        {
            InitializeComponent();

            IServiceProvider container = ((App)Windows.UI.Xaml.Application.Current).Container;
            DataContext = ActivatorUtilities.GetServiceOrCreateInstance(container, typeof(CurrencySelectorViewModel));
            _currencySelectorViewModel = DataContext as CurrencySelectorViewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var navigationInfo = e.Parameter as NavigationInfo;

            _currencySelectorViewModel.CurrentValute = navigationInfo.CurrentValute;
            _currencySelectorViewModel.SelectedValute = navigationInfo.Valute;
        }

        private void Page_KeyUp(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Escape)
                _currencySelectorViewModel.Back();
        }
    }
}
