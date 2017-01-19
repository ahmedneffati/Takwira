using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takwira.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Plugin.ExternalMaps;
namespace Takwira.Views
{
    
      public partial class AfficheTerrain : ContentPage
    {
        public AfficheTerrain()
        {
            InitializeComponent();
        }
        private TerrainViewModel fvm;
        public AfficheTerrain(TerrainViewModel f)
        {
            InitializeComponent();
            fvm = f;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var items = fvm.TerrainsList;
            map1.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(36.89, 10.18), Distance.FromKilometers(10)));
            foreach (var i in items)
            {
                var p = new Pin
                {
                    Position = new Position(i.Latitude, i.Longitude),
                    Label = i.Nom,
                    Address = i.Description


                };
                p.Clicked += Pin_Clicked;
                map1.Pins.Add(p);

            }


        }
        private Pin s;
        private void Pin_Clicked(object sender, System.EventArgs e)
        {
            s = sender as Pin;
            //  place.BindingContext = fvm.FoursquareVenues.Response.Groups[0].Items.Find(item => item.Venue.Name == s?.Label);
            // DisplayAlert(s?.Label, s.Address, "OK");

        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            CrossExternalMaps.Current.NavigateTo(s.Label, s.Position.Latitude, s.Position.Longitude, NavigationType.Driving);
        }
    }
}

