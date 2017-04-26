using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takwira.ViewModels;
using Xamarin.Forms;

namespace Takwira.Views
{
    public partial class Menu : MasterDetailPage
    {
        public Menu()
        {
            InitializeComponent();
            IsPresented = true;
            NavigationPage.SetHasNavigationBar(this, false);
            Detail = new NavigationPage(new AjouterTerrain());
        }

        private async void AllerListTerrainAsync(object sender, EventArgs e)
        {

            var four = new TerrainViewModel();
            await four.InitializerDataASYNC();
            Detail = new NavigationPage(new AfficheTerrain(four));


        }
        public void AllerAjouterTerrain(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new AjouterTerrain());
        }


        public async void AllerConnexion(object sender, EventArgs e)
        {
            MySharedPreferences.email = "";
            await Navigation.PushAsync(new Welcome());
        }


    }
}