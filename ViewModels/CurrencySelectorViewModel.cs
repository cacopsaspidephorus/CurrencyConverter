using CurrencyConverter.Models;
using CurrencyConverter.Mvvm;
using CurrencyConverter.Pages;
using CurrencyConverter.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace CurrencyConverter.ViewModels
{
    public class CurrencySelectorViewModel : BindableBase
    {
        private Valute _selectedValute;

        private readonly ICurrencyService _currencyService;
        private readonly INavigationService _navigationService;

        public ValuteSide CurrentValute { get; set; }

        public Valute SelectedValute
        {
            get => _selectedValute;
            set
            {
                SetProperty(ref _selectedValute, value);

                DeselectAll();

                if (_selectedValute != null)
                    _selectedValute.IsSelected = true;
            }
        }

        public IEnumerable<Valute> Valutes { get; private set; }

        public ICommand SelectionChangedCommand { get; }

        public CurrencySelectorViewModel(ICurrencyService currencyService, INavigationService navigationService)
        {
            _currencyService = currencyService;
            _navigationService = navigationService;

            SelectionChangedCommand = new RelayCommand(OnSelectionChanged);

            Valutes = GetValutesWithRub();
        }

        private void OnSelectionChanged(object obj)
        {
            NavigateTo(SelectedValute);
        }

        public void Back()
        {
            NavigateTo();
        }

        private void NavigateTo(Valute valute = null)
        {
            _navigationService.NavigateTo(typeof(СalculatorPage), new NavigationInfo
            {
                CurrentValute = CurrentValute,
                Valute = valute
            });
        }

        private void DeselectAll()
        {
            foreach (Valute valute in Valutes)
                valute.IsSelected = false;
        }

        private IEnumerable<Valute> GetValutesWithRub()
        {
            IList<Valute> valutes = _currencyService.Valutes.ToList();
            valutes.Insert(0, new Valute
            {
                Name = "Рубль",
                CharCode = "RUB",
                Nominal = 1,
                NumCode = 643,
                Value = 1,
                Previous = 1
            });

            return valutes;
        }
    }
}
