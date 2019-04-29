using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;


namespace PushNotificationsTest
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            check();

            CustomProperties customProperties = new CustomProperties();
            customProperties.Set("","");
            AppCenter.SetCustomProperties(customProperties);
        }

        async void check()
        {
            bool appcenterIsEnabled = await AppCenter.IsEnabledAsync();
            System.Console.Write(appcenterIsEnabled);
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Analytics.TrackEvent("Button Clicked");
            try
            {
                throw new System.ArgumentException();
            }
            catch (Exception exception)
            {
                Crashes.TrackError(exception);
            }
        }
    }
}
