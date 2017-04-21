using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takwira.Views;
using Xamarin.Forms;

namespace Takwira
{
    public partial class Welcome : ContentPage
    {
        public Welcome()
        {
            InitializeComponent();
        }
        private async void Button_ClickedAsync2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConnexionJoueur());

        }
        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConnexionProprietaire());

        }
    }
}
