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
	public partial class CurrencyPage : ContentPage
	{
		public CurrencyPage ()
		{
			InitializeComponent ();
            BindingContext = new ViewModels.CurrencyViewModel(Navigation);
		}
	}
}