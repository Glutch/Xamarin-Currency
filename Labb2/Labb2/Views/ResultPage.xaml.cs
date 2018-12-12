using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Labb2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResultPage : ContentPage
	{
		public ResultPage (string firstCurrency, string secondCurrency, float amount)
		{
			InitializeComponent ();
            BindingContext = new ViewModels.ResultViewModel(firstCurrency, secondCurrency, amount);
		}
	}
}