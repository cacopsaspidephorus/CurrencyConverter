using System;

namespace CurrencyConverter.Services
{
    public interface INavigationService
    {
        bool NavigateTo(Type source, object parameter = null);
    }
}
