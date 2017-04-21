using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takwira.Views;
using Xamarin.Forms;

namespace Takwira
{
    public partial class HelpAccount : ContentPage
    {
       public HelpAccount()
		{
			InitializeComponent();
		}
		private async void send(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ConnexionJoueur());
	    }		
	}
}
