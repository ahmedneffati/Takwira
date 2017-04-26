using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Takwira.Models;
using Takwira.Services;
using Xamarin.Forms;


namespace Takwira.Views
{
    public partial class ConnexionJoueur : ContentPage
    {
        
            public ConnexionJoueur()
            {

                InitializeComponent();
            
        }
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
                    //string Url = string.Format("http://takwira.azurewebsites.net/api/Joueurs/Connexion/" + email.Text.ToString() + "/" + pass.Text.ToString());
                   //// HttpClient client = new HttpClient();
                    //string json = await client.GetStringAsync(Url);
                    // Joueur utilisateur = JsonConvert.DeserializeObject<Joueur>(json);
                   // if (json.Length > 20)

                        Joueur j;
                    JoueurServices u = new JoueurServices();
                    j = new Joueur();
                    j = await u.getJoueurAsync(email.Text, pass.Text);
                    
                        string emailj = email.Text;
                        email.Text = "";
                        pass.Text = "";
                        MySharedPreferences.email = emailj;
                        MySharedPreferences.type = "J";
                        await Navigation.PushAsync(new MenuJoueur(emailj));
                      
                    

                    // await Navigation.RemovePage(Connexion);
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "Login or password is incorrect", "Ok");
                }





            }
        }
            private async void Button_ClickedAsync2(object sender, EventArgs e)
            {


                await Navigation.PushAsync(new InscriptionJoueur());



            }
            private async void ButtRec(object sender, EventArgs e)
            {

                await Navigation.PushAsync(new HelpAccount());
            }
        }
    }