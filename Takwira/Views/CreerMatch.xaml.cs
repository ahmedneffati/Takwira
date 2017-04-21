using Plugin.Geolocator;
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
    public partial class CreerMatch : ContentPage
    {
        string emailJoueur;
        public CreerMatch()
        {
            InitializeComponent();
            positionAsync();
        }
        public CreerMatch(string email)
        {
            emailJoueur = email;
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
                    la.Text = positions.Latitude.ToString();
                    lo.Text = positions.Longitude.ToString();
                }
                else
                {
                    await DisplayAlert("Error", "activate the GPS", "Ok");
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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            MatchServices u = new MatchServices();
            Match j = new Match();
            if (la.Text.Equals("") || lo.Text.Equals("") || desc.Text.Equals("") || nb.Text.Equals(""))
            {
                await DisplayAlert("Error", "there is atrebute is empty", "ok");
            }
            else
            {

                j.Description = desc.Text;
                j.NbDeJoueur = int.Parse(nb.Text);
                j.Latitude = float.Parse(la.Text);
                j.Longitude = float.Parse(lo.Text);
                j.OrganisateurEmail = "aaa@aaa.aa";

                string ch = "";
                //  2019 - 02 - 27T20: 20:20
                ch = ch + date.Date.Year + '-' + date.Date.Month + '-' + date.Date.Day + 'T' + time.Time.Hours + ':' + time.Time.Minutes + ':' + "00";
                j.Date = DateTime.Parse(ch);

                await u.PostMatchsAsync(j);
                await Navigation.PushAsync(new ConnexionJoueur());
            }

        }

    }
}