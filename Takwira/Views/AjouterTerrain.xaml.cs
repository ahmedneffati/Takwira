using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Takwira.Views
{
    public partial class AjouterTerrain : ContentPage
    {
        public AjouterTerrain()
        {
            InitializeComponent();
            positionAsync();
       

        }
        public async Task positionAsync()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                if (locator.IsGeolocationEnabled)
                {
                    var positions = await locator.GetPositionAsync(10000);
                    positions.ToString();
                    lat.Text = positions.Latitude.ToString();
                    lon.Text = positions.Longitude.ToString();
                }
                else
                {
                    await DisplayAlert("Erreur", "Ce Compte n'existe pas", "Ok");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Unable to get location, may need to increase timeout: " + ex);
            }
            /*  var locat = CrossGeolocator.Current;
              locat.DesiredAccuracy = 5000;
              var position = await locat.GetPositionAsync(1000000);
              a1.Text = position.Latitude.ToString();

                lon.Text = position.Longitude.ToString();
                */
        }

    }
}