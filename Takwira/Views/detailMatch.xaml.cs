using Plugin.ExternalMaps;
using Plugin.ExternalMaps.Abstractions;
using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takwira.Models;
using Takwira.Services;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Takwira.Views
{
    public partial class detailMatch : ContentPage
    {
        private Joueur j;
        private MatchJoueurServices mJS = new MatchJoueurServices();
        public detailMatch()
        {
            InitializeComponent();
        }
        
        private Joueur Organisateur;
        Match match;
        public detailMatch(Match m)
        {
            InitializeComponent();
            this.match = m; ;
            desc.Text = m.Description;
            Date.Text = match.Date.ToString();
            desc.Text = m.Description;
            getOrganInformations();


        }
        private async void getOrganInformations()
        {
            JoueurServices u = new JoueurServices();
            j = new Joueur();
            j = await u.getJoueurAsync(match.OrganisateurEmail);
        }
        private void Button_Clicked(object sender, System.EventArgs e)
        {
            CrossExternalMaps.Current.NavigateTo(match.Description, match.Latitude,match.Longitude, NavigationType.Driving);
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("confirm", "are you sure", "yes", "no");
            if (answer)
            {
                MatchJoueur parti = new MatchJoueur();
                parti.MatchId = match.Id;
                parti.JoueurEmail = MySharedPreferences.email;
                parti.EtatDeConfirmation = "pas encore";
                // reser.HoraireId = picker.SelectedIndex;
                //reser.IdTerrain = 11;

                await mJS.PostMatchJoueursAsync(parti);
            }
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            var sms = CrossMessaging.Current.SmsMessenger;
            if (sms.CanSendSms)
                sms.SendSms(j.NumTel, " hello there");
            else
                await DisplayAlert("Error", "Impossible", "Ok");
        }
        private async void TapGestureRecognizer_Tapped1(object sender, EventArgs e)
        {
            // Make Phone Call
            var phoneCallTask = MessagingPlugin.PhoneDialer;
            if (phoneCallTask.CanMakePhoneCall)
                phoneCallTask.MakePhoneCall(j.NumTel);
            else
                await DisplayAlert("Error", "Impossible", "Ok");
        }
        private async void TapGestureRecognizer_Tapped2(object sender, EventArgs e)
        {
            var emailTask = MessagingPlugin.EmailMessenger;
            if (emailTask.CanSendEmail)
            {
                // Send simple e-mail to single receiver without attachments, CC, or BCC.
                emailTask.SendEmail(j.Email, "I want", "Hello I want to be with you!");

                // Send a more complex email with the EmailMessageBuilder fluent interface.

               // var email = new EmailMessageBuilder()
                //  .To("plugins@xamarin.com")
                 // .Cc(t.EmailProp)
                  //.Bcc(new[] { "plugins.bcc@xamarin.com", "plugins.bcc2@xamarin.com" })
                  //.Subject("Xamarin Messaging Plugin")
                  //.Body("Hello from your friends at Xamarin!")
                  //.Build();

               // emailTask.SendEmail(email);
            }
            else
                await DisplayAlert("Error", "Impossible", "Ok");
        }

    

    }
}