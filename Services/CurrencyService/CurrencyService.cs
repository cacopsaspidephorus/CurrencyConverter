using CurrencyConverter.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace CurrencyConverter.Services
{
    internal class CurrencyService : ICurrencyService, IDisposable
    {
        private const string Url = "https://www.cbr-xml-daily.ru/daily_json.js";
        private readonly WebClient _webClient = new WebClient();

        public event Action LoadCompleted;
        public IEnumerable<Valute> Valutes { get; private set; }

        public CurrencyService()
        {
            Init();
        }

        public void Dispose()
        {
            _webClient?.Dispose();
        }

        private void Init()
        {
            _webClient.DownloadStringCompleted += (s, e) =>
            {
                var list = new List<Valute>();

                JObject result = JObject.Parse(e.Result);
                IJEnumerable<JToken> jValutes = result["Valute"].Values();
                Valutes = jValutes.Select(x => x.ToObject<Valute>()).ToList();

                LoadCompleted?.Invoke();
            };

            _webClient.DownloadStringAsync(new Uri(Url));
        }
    }
}
