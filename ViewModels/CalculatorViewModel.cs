using CurrencyConverter.Models;
using CurrencyConverter.Mvvm;
using CurrencyConverter.Pages;
using CurrencyConverter.Services;
using System.Windows.Input;

namespace CurrencyConverter.ViewModels
{
    public class CalculatorViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;

        private decimal _leftSumm;
        private decimal _rightSumm;

        private Valute _leftValute;
        private Valute _rightValute;

        private bool _needRecalcLeft = true;
        private bool _needRecalcRight = true;

        public decimal LeftSumm
        {
            get => _leftSumm;
            set
            {
                SetProperty(ref _leftSumm, value);
                RecalcRight();
            }
        }

        public decimal RightSumm
        {
            get => _rightSumm;
            set
            {
                SetProperty(ref _rightSumm, value);
                RecalcLeft();
            }
        }

        public Valute LeftValute
        {
            get => _leftValute;
            set
            {
                SetProperty(ref _leftValute, value);
                RecalcLeft();
            }
        }

        public Valute RightValute
        {
            get => _rightValute;
            set
            {
                SetProperty(ref _rightValute, value);
                RecalcRight();
            }
        }

        public ICommand SelectLeftCurrencyCommand { get; }
        public ICommand SelectRightCurrencyCommand { get; }
        public ICommand SwapCurrencyCommand { get; }

        public CalculatorViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            SelectLeftCurrencyCommand = new RelayCommand(o => SelectCurrency(LeftValute, ValuteSide.Left));
            SelectRightCurrencyCommand = new RelayCommand(o => SelectCurrency(RightValute, ValuteSide.Right));
            SwapCurrencyCommand = new RelayCommand(o => Swap());
        }

        private void RecalcLeft()
        {
            if (!_needRecalcLeft || LeftValute == null || RightValute == null)
                return;

            _needRecalcRight = false;
            LeftSumm = RightSumm * (RightValute.Value / RightValute.Nominal) / (LeftValute.Value / LeftValute.Nominal);
            _needRecalcRight = true;
        }

        private void RecalcRight()
        {
            if (!_needRecalcRight || LeftValute == null || RightValute == null)
                return;

            _needRecalcLeft = false;
            RightSumm = LeftSumm * (LeftValute.Value / LeftValute.Nominal) / (RightValute.Value / RightValute.Nominal);
            _needRecalcLeft = true;
        }

        private void SelectCurrency(Valute valute, ValuteSide currentValute)
        {
            _navigationService.NavigateTo(typeof(CurrencySelectorPage), new NavigationInfo
            {
                Valute = valute,
                CurrentValute = currentValute
            });
        }

        private void Swap()
        {
            _needRecalcLeft = false;
            _needRecalcRight = false;

            decimal tempSumm = LeftSumm;
            LeftSumm = RightSumm;
            RightSumm = tempSumm;

            Valute tempValute = LeftValute;
            LeftValute = RightValute;
            RightValute = tempValute;

            _needRecalcLeft = true;
            _needRecalcRight = true;
        }
    }
}
