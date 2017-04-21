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
    public partial class InscriptionProprietaire : ContentPage
    {
        public InscriptionProprietaire()
        {
            InitializeComponent();
            
        }
        private async void creer_Clicked(object sender, EventArgs e)
        {
            ProprietaireServices u = new ProprietaireServices();
            Proprietaire j = new Proprietaire();
            if (email.Text.Equals("") || pass.Text.Equals("") || pass.Text.Equals("") || full.Text.Equals(""))
            {
                await DisplayAlert("Error", "there is atrebute is empty", "ok");
            }
            else
            {

                j.Email = email.Text;
                j.MotDePass = pass.Text;
                j.NomEtPrenom = full.Text;
                j.NumTel = phoneN.Text;
                await u.PostProprietairesAsync(j);
                await Navigation.PushAsync(new ConnexionProprietaire());
            }

        }
    }
}