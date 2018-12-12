using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Labb2.ViewModels
{
    public class ResultViewModel: BaseViewModel
    {
        readonly HttpClient client;
        private string firstCurrency;
        private string secondCurrency;
        private float amount;
        private string resultText = "Fetching latest currency data";

        public ResultViewModel(string firstCurrency, string secondCurrency, float amount)
        {
            client = new HttpClient();

            this.firstCurrency = firstCurrency;
            this.secondCurrency = secondCurrency;
            this.amount = amount;

            FetchExchangeData();
        }

        private async void FetchExchangeData()
        {
            string url = "https://api.exchangeratesapi.io/latest";
            var uri = new Uri(url);
            var res = await client.GetAsync(uri);

            if(res.IsSuccessStatusCode)
            {
                var body = await res.Content.ReadAsStringAsync();
                var api = JsonConvert.DeserializeObject<Models.Exchange>(body);

                double value = api.Rates[secondCurrency] / api.Rates[firstCurrency] * amount;
                double prettyValue = Math.Round(value, 2);
                UpdateResult(prettyValue);
            }
        }

        private void UpdateResult(double value)
        {
            ResultText = $"{amount}{firstCurrency} = {value}{secondCurrency}";
        }

        public string ResultText
        {
            get => resultText;
            set => SetProperty(storage: ref resultText, value: value);
        }
    }
}