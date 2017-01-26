using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Takwira.Views;
using Xamarin.Forms;

namespace Takwira
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new CreerReservation());

           // MainPage =new Takwira.Views.Menu();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
