using System;
using System.Windows.Input;
using Xamarin.Forms;
using Labb2.Validation;

namespace Labb2.ViewModels
{
    public class CurrencyViewModel: BaseViewModel
    {
        INavigation Navigation;
        public float amount;
        private string[] currencies;
        private int firstCurrency;
        private int secondCurrency;
        private ICommand calculateCommand;

        public ValidatableObject<float> InputValidation { get; set; } = new ValidatableObject<float>();

        public CurrencyViewModel(INavigation Navigation)
        {
            this.Navigation = Navigation;
            Currencies = new string[] { "USD", "SEK", "JPY", "NOK", "DKK" };
            firstCurrency = 0;
            secondCurrency = 0;
            amount = 0;
            CalculateCommand = new Command(Calculate);
            AddValidations();
        }

        void AddValidations()
        {
            InputValidation._validations.Add(new IsNotZero<float>
            {
                ValidationMessage = "Please enter a number, not 0!"
            });
        }

        public string[] Currencies
        {
            get => currencies;
            set => SetProperty(storage: ref currencies, value: value);
        }

        public int FirstCurrency
        {
            get => firstCurrency;
            set => SetProperty(storage: ref firstCurrency, value: value);
        }

        public int SecondCurrency
        {
            get => secondCurrency;
            set => SetProperty(storage: ref secondCurrency, value: value);
        }

        public float Amount
        {
            get => amount;
            set => SetProperty(storage: ref amount, value: value);
        }

        public ICommand CalculateCommand
        { 
            get => calculateCommand;
            private set => SetProperty(storage: ref calculateCommand, value: value); 
        }

        async void Calculate()
        {
            if (Validate()) {
                await Navigation.PushAsync(new Views.ResultPage(Currencies[firstCurrency], Currencies[secondCurrency], amount));
            }
        }

        bool Validate()
        {
            InputValidation.Value = amount;
            return InputValidation.Validate();
        }
    }
}
