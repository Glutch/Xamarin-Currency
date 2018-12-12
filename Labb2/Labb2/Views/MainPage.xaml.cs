using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Labb2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            GoToCurrencyPage.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new Views.CurrencyPage());
            };

        }

        
    }
}
