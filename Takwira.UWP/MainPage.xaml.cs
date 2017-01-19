using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Takwira.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Xamarin.FormsMaps.Init("sdrlAHzlNUH9yKdKR53o~etleG4Pmi3jp_GI8w136Eg~AvGH-WeRPXRexIIcgFWI_lz8reoU4kfRUyD5WSDUA9PmZmDSixkMyxxfmRrsDPzr");
            

            LoadApplication(new Takwira.App());
        }
    }
}
