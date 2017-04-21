using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takwira.ViewModels;
using Xamarin.Forms;

namespace Takwira.Views
{
    public partial class MenuJoueur : MasterDetailPage
    {
        string emailJoueur;
        public MenuJoueur()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            IsPresented = true;

            Detail = new NavigationPage(new CreerMatch());
        }
        public MenuJoueur(string email)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            IsPresented = true;
            emailJoueur = email;
            Detail = new NavigationPage(new CreerMatch());
        }

        private async void AllerListTerrainAsync(object sender, EventArgs e)
        {

            var four = new TerrainViewModel();
            await four.InitializerDataASYNC();
            Detail = new NavigationPage(new AfficheTerrain(four));


        }

        public void AllerReservation(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new CreerReservation(emailJoueur));
        }
        public void AllerCreerMatch(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new CreerMatch(emailJoueur));
        }
        public async void AllerConnexion(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Welcome()); 
        }


    }
}