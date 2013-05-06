using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;

namespace HTML5App1
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Url of Home page
        private string MainUri = "/Html/index.html";

        // Constructor
        public MainPage()
        {
            InitializeComponent();

        }

        private void Browser_Loaded(object sender, RoutedEventArgs e)
        {
            Browser.IsScriptEnabled = true;

            // Add your URL here
            Browser.Navigate(new Uri(MainUri, UriKind.Relative));

Browser.LoadCompleted += (s, args) =>
{
    // setup the image to display
    var img = "";
    var height = "800px";
    switch (ResolutionHelper.CurrentResolution)
    {
        case Resolutions.HD720p:
            img = "images/bg-720p.png";
                        
            break;
        case Resolutions.WXGA:
            img = "images/bg-wxga.png";
            height = "800px";
            break;
        case Resolutions.WVGA:
            height = "800px";
            img = "images/bg-wvga.png";
            break;
        default:
            throw new InvalidOperationException("Unknown resolution type");
    }
    Browser.InvokeScript("setImage", new string[] { img, height });
};

          
        }


        // Handle navigation failures.
        private void Browser_NavigationFailed(object sender, System.Windows.Navigation.NavigationFailedEventArgs e)
        {
            MessageBox.Show("Navigation to this page failed, check your internet connection");
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
        }
    }

    public enum Resolutions { WVGA, WXGA, HD720p };

    public static class ResolutionHelper
    {
        private static bool IsWvga
        {
            get
            {
                return App.Current.Host.Content.ScaleFactor == 100;
            }
        }

        private static bool IsWxga
        {
            get
            {
                return App.Current.Host.Content.ScaleFactor == 160;
            }
        }

        private static bool Is720p
        {
            get
            {
                return App.Current.Host.Content.ScaleFactor == 150;
            }
        }

        public static Resolutions CurrentResolution
        {
            get
            {
                if (IsWvga) return Resolutions.WVGA;
                else if (IsWxga) return Resolutions.WXGA;
                else if (Is720p) return Resolutions.HD720p;
                else throw new InvalidOperationException("Unknown resolution");
            }
        }
    }
}
