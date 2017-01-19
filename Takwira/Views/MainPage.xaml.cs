using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Takwira.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();//>keytool -list -v -keystore "C:\Users\ahmed\AppData\Local\Xamarin\Mono for Android\debug.keystore"

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
