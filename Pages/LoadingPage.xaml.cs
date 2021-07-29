using CurrencyConverter.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using Windows.UI.Xaml.Controls;

namespace CurrencyConverter.Pages
{
    public sealed partial class LoadingPage : Page
    {
        public LoadingPage()
        {
            InitializeComponent();

            IServiceProvider container = ((App)Windows.UI.Xaml.Application.Current).Container;
            DataContext = ActivatorUtilities.GetServiceOrCreateInstance(container, typeof(LoadingViewModel));
        }
    }
}
