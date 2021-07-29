using CurrencyConverter.Mvvm;
using Newtonsoft.Json;

namespace CurrencyConverter.Models
{
    public class Valute : BindableBase
    {
        private bool _isSelected;

        [JsonProperty("ID")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("CharCode")]
        public string CharCode { get; set; }

        [JsonProperty("NumCode")]
        public int NumCode { get; set; }

        [JsonProperty("Nominal")]
        public int Nominal { get; set; }

        [JsonProperty("Value")]
        public decimal Value { get; set; }

        [JsonProperty("Previous")]
        public decimal Previous { get; set; }

        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }
    }
}
