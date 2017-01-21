using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Takwira.Views
{
    public partial class CreerMatch : ContentPage
    {
        public CreerMatch()
        {
            InitializeComponent();
            positionAsync();
        }
        public async Task positionAsync()
        {
            var locat = CrossGeolocator.Current;
            locat.DesiredAccuracy = 5000;
            var position = await locat.GetPositionAsync(1000000);
            la.Text = position.Latitude.ToString();

            lo.Text = position.Longitude.ToString();
        }
    }
}