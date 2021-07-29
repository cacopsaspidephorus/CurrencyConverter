using CurrencyConverter.Mvvm;
using CurrencyConverter.Pages;
using CurrencyConverter.Services;

namespace CurrencyConverter.ViewModels
{
    public class LoadingViewModel : BindableBase
    {
        private bool _isProgressRingActive;
        private readonly ICurrencyService _currencyService;

        public bool IsProgressRingActive
        {
            get => _isProgressRingActive;
            set => SetProperty(ref _isProgressRingActive, value);
        }

        public LoadingViewModel(ICurrencyService currencyService, INavigationService navigationService)
        {
            _currencyService = currencyService;

            IsProgressRingActive = true;

            _currencyService.LoadCompleted += () =>
            {
                IsProgressRingActive = false;
                navigationService.NavigateTo(typeof(СalculatorPage));
            };
        }
    }
}
