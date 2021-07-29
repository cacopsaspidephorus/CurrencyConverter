using System;
using Windows.UI.Xaml.Data;

namespace CurrencyConverter.Converters
{
    public class StringToDecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return String.Format("{0:0.##}", value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            Decimal.TryParse((string)value, out decimal result);
            return result;
        }
    }
}
