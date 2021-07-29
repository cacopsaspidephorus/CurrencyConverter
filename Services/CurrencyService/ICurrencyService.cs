using CurrencyConverter.Models;
using System;
using System.Collections.Generic;

namespace CurrencyConverter.Services
{
    public interface ICurrencyService
    {
        event Action LoadCompleted;
        IEnumerable<Valute> Valutes { get; }
    }
}
