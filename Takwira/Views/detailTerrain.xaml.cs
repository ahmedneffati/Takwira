using Plugin.ExternalMaps;
using Plugin.ExternalMaps.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Takwira.Views
{
    public partial class detailTerrain : ContentPage
    {
        private Pin s;

        public detailTerrain()
        {
            InitializeComponent();
        }

        public detailTerrain(Pin s)
        {
            InitializeComponent();
            this.s = s;
        }
        private void Button_Clicked(object sender, System.EventArgs e)
        {
            CrossExternalMaps.Current.NavigateTo(s.Label, s.Position.Latitude, s.Position.Longitude, NavigationType.Driving);
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreerReservation());
        }
    }
}
