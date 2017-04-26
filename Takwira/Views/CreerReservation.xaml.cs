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
    public partial class CreerReservation : ContentPage
    {
        HoraireServices u = new HoraireServices();
        ReservationServices r = new ReservationServices();
        List<Horaire> h;
        string emailJoueur;
        public CreerReservation()
        {
            InitializeComponent();
            date_DateSelected(null, null);


        }
        public CreerReservation(string email)
        {
            InitializeComponent();
            date_DateSelected(null, null);
            emailJoueur = email;

        }

        private async void date_DateSelected(object sender, DateChangedEventArgs e)
        {
            h = await u.getHorairesAsync();
            foreach (var x in h)
            {
                picker.Items.Add(x.Intervalle);
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("confirm", "are you sure", "yes", "no");
            if (answer)
            {
                Reservation reser = new Reservation();
                reser.Date = date.Date;
                reser.EmailJoueur = MySharedPreferences.email;
                // reser.HoraireId = picker.SelectedIndex;
                //reser.IdTerrain = 11;

                await r.PostReservationsAsync(reser);

            }


        }
    }
}