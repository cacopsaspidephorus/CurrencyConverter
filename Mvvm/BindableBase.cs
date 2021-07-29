using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CurrencyConverter.Mvvm
{
    public abstract class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(property, value))
                return;
            
            property = value;
            OnPropertyChanged(propertyName);
        }
    }
}
