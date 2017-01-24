using Plugin.Geolocator;
using Plugin.Media;
using Plugin.Media.Abstractions;
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
        private MediaFile _mediaFile;
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Photo", "add image from", "PICK Photo","Take Photo");
            await CrossMedia.Current.Initialize();
            if (answer)
            {
               
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("No PickPhoto", ":( No PickPhoto available", "OK");
                    return;
                }
                _mediaFile = await CrossMedia.Current.PickPhotoAsync();
                if (_mediaFile == null)
                {
                    return;
                }
                x.Source = ImageSource.FromStream(() =>
                  {
                      return _mediaFile.GetStream();
                  });
                await DisplayAlert("good", _mediaFile.Path, "Ok");
            }
           
            else
            {
                if(!CrossMedia.Current.IsCameraAvailable|| !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No PickPhoto", ":( No PickPhoto available", "OK");
                    return;
                }
                _mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory="sample",
                    Name = "myImage.jpg"
                });
                if (_mediaFile == null)
                    return;
                await DisplayAlert("good", _mediaFile.Path, "Ok");
                x.Source = ImageSource.FromStream(() =>
                {
                    return _mediaFile.GetStream();
                });


            }
        }
        private async void InsertFile(object sender, EventArgs e)
        {
            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(_mediaFile.GetStream()),
               "\"file\"", $"\"{_mediaFile.Path}\"");
            //http://takwira.azurewebsites.net/uploads/image_.jpg
            var httpclient = new HttpClient();
            string name = lon.Text ;
            var up = "http://takwira.azurewebsites.net/file/uploads/"+name+"/";
            var httpRM = await httpclient.PostAsync(up, content);
          //  path.Text = "http://takwira.azurewebsites.net/uploads/image_"+name+".jpg";
            TerrainServices u = new TerrainServices();
            Terrain t = new Terrain();
            t.Description = desc.Text.ToString();
            t.Nom = nom.Text.ToString();
            float xx;
            t.Latitude =float.Parse( lat.Text.ToString());
            t.Longitude = float.Parse(lon.Text.ToString());
            t.PathImage= "http://takwira.azurewebsites.net/uploads/image_" + name + ".jpg";

            await u.PostTerrainsAsync(t);

        }

        }
}