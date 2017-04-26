using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takwira.Models;
using Takwira.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Takwira.Views
{
    public partial class AfficherMatchs : ContentPage
    {
        public AfficherMatchs()
        {
            InitializeComponent();
        }
        private MatchViewModel fvm;
        List<Match> items;
        public AfficherMatchs(MatchViewModel f)
        {
            InitializeComponent();
            fvm = f;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            items = fvm.MatchsList;
            map1.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(36.89, 10.18), Distance.FromKilometers(10)));
            foreach (var i in items)
            {
                var p = new Pin
                {
                    Position = new Position(i.Latitude, i.Longitude),
                    Label = i.Description,
                    Address = i.Date.ToString()



                };
                p.Clicked += Pin_Clicked;
                map1.Pins.Add(p);

            }


        }
        private Pin s;
        private async void Pin_Clicked(object sender, System.EventArgs e)
        {
           Match t = null;
            s = sender as Pin;
            foreach (var i in items)
            {
                if (i.Description == s.Label)
                {
                    t = i;
                }
            }
            await Navigation.PushAsync(new detailMatch(t));
            //  place.BindingContext = fvm.FoursquareVenues.Response.Groups[0].Items.Find(item => item.Venue.Name == s?.Label);
            // DisplayAlert(s?.Label, s.Address, "OK");

        }


    }
}

