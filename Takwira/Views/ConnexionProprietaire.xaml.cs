using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Takwira.Models;
using Xamarin.Forms;
using Plugin.Connectivity.Abstractions;
using Takwira.Services;

namespace Takwira.Views
{
    public partial class ConnexionProprietaire : ContentPage
    {
        public ConnexionProprietaire()
        {
            InitializeComponent();
            //CrossConnectivity.Current.ConnectivityChanged += onChanged;
        }

       /* private void onChanged(object sender, ConnectivityChangedEventArgs e)
        {
          new  ConnexionProprietaire();
        }
        */

        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Error", "there is no Connection", "Ok");
            }
            else
            {

                try
                {
                    //http://takwira.azurewebsites.net/api/Joueurs/Connexion/azdadz/huuih
                   // string Url = string.Format("http://takwira.azurewebsites.net/api/Proprietaires/Connexion/" + email.Text.ToString() + "/" + pass.Text.ToString());
                    //HttpClient client = new HttpClient();
                    Proprietaire j;
                    ProprietaireServices u = new ProprietaireServices();
                    j = new Proprietaire();
                    j = await u.getProprietaireAsync(email.Text,pass.Text);
                   // string json = await client.GetStringAsync(Url);
                   // if (json.Length > 20)
                        MySharedPreferences.email = email.Text;
                    MySharedPreferences.type = "P";
                    email.Text = "";
                    pass.Text = "";
                    
                    await Navigation.PushAsync(new Menu());

                    // await Navigation.RemovePage(Connexion);
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Erreur", "Login or password is incorrect", "Ok");
                }



            }
        }

        private async void Button_ClickedAsync2(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new InscriptionProprietaire());
        }
        private async void ButtRec(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new HelpAccount());
        }

    }
}