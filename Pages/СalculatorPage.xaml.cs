using CurrencyConverter.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CurrencyConverter.Pages
{
    public sealed partial class СalculatorPage : Page
    {
        public СalculatorPage()
        {
            InitializeComponent();

            IServiceProvider container = ((App)Windows.UI.Xaml.Application.Current).Container;
            DataContext = ActivatorUtilities.GetServiceOrCreateInstance(container, typeof(CalculatorViewModel));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter == null)
                return;

            var navigationInfo = e.Parameter as NavigationInfo;

            if (navigationInfo.Valute == null)
                return;

            var calculatorViewModel = DataContext as CalculatorViewModel;     

            switch (navigationInfo.CurrentValute)
            {
                case ValuteSide.Left:
                    calculatorViewModel.LeftValute = navigationInfo.Valute;
                    break;

                case ValuteSide.Right:
                    calculatorViewModel.RightValute = navigationInfo.Valute;
                    break;
            }
        }

        private void TextBox_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = !(Decimal.TryParse(args.NewText, out _));
        }
    }
}