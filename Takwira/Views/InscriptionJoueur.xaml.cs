using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takwira.Models;
using Takwira.Services;
using Xamarin.Forms;

namespace Takwira.Views
{
    public partial class InscriptionJoueur : ContentPage
    {
        public InscriptionJoueur()
        {
            InitializeComponent();
        }

        private async void creer_Clicked(object sender, EventArgs e)
        {
            JoueurServices u = new JoueurServices();
            Joueur j = new Joueur();
            if (email.Text.Equals("") || pass.Text.Equals("") || pass.Text.Equals("") || full.Text.Equals(""))
            {
                await DisplayAlert("Error", "there is atrebute is empty", "ok");
            }
            else
            {
            
            j.Email = email.Text;
            j.MotDePass = pass.Text;
            j.DateDeNaiss = dateN.Date;
            j.NomEtPrenom = full.Text;
            j.NumTel = phoneN.Text;
            await u.PostJoueursAsync(j);
            await Navigation.PushAsync(new ConnexionJoueur());
        }
            
        }
    }
}
