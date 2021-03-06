﻿using Plugin.ExternalMaps;
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
    public partial class detailTerrain : ContentPage
    {
        private Pin s;
        private Terrain t;
      private  Proprietaire j;
        public detailTerrain()
        {
            InitializeComponent();
            
        }
        public detailTerrain(Pin s , Terrain t)
        {
            InitializeComponent();
            this.s = s;
            this.t = t;
            nom.Text = t.Nom;
            desc.Text = t.Description;
            image.Source = t.PathImage;
            getPropInformations();


        }
        private async void getPropInformations()
        {
            ProprietaireServices u = new ProprietaireServices();
             j = new Proprietaire();
            j = await u.getProprietaireAsync(t.EmailProp);
        }
        private void Button_Clicked(object sender, System.EventArgs e)
        {
            CrossExternalMaps.Current.NavigateTo(s.Label, s.Position.Latitude, s.Position.Longitude, NavigationType.Driving);
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreerReservation());
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            
            var sms = CrossMessaging.Current.SmsMessenger;
            if (sms.CanSendSms)
                sms.SendSms(j.NumTel, "well hello there");
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
                emailTask.SendEmail(t.EmailProp, "I want", "Hello I want to ...!");

                // Send a more complex email with the EmailMessageBuilder fluent interface.

                // var email = new EmailMessageBuilder()
                // .To("plugins@xamarin.com")
                //.Cc(t.EmailProp)
                //.Bcc(new[] { "plugins.bcc@xamarin.com", "plugins.bcc2@xamarin.com" })
                //.Subject("Xamarin Messaging Plugin")
                //.Body("Hello from your friends at Xamarin!")
                //.Build();

                //  emailTask.SendEmail(email);
            }
            else
                await DisplayAlert("Error", "Impossible", "Ok");
        }

    }
}