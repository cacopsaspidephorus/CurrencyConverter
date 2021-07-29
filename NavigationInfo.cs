using CurrencyConverter.Models;

namespace CurrencyConverter
{
    public class NavigationInfo
    {
        public Valute Valute { get; set; }
        public ValuteSide CurrentValute { get; set; }
    }

    public enum ValuteSide
    {
        Left,
        Right
    }
}
