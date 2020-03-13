using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCenterDemo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Analytics.TrackEvent("Getting started!");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            // Note: checks for debug vs release configuration.
            // You can only use it when debugging as it won't work for release apps.
            Crashes.GenerateTestCrash(); 
        }
        private void Button_Clicked_Error1(object sender, EventArgs e)
        {
            try
            {
                int[] myNumbers = { 1, 2, 3 };
                Console.WriteLine(myNumbers[10]);
            }
            catch (Exception exception)
            {
                Crashes.TrackError(exception);
            }
        }

        private void Button_Clicked_Error2(object sender, EventArgs e)
        {
            int[] myNumbers = { 1, 2, 3 };

            try
            {
                Console.WriteLine(myNumbers[10]);
            }
            catch (Exception exception)
            {
                // You can also optionally add one binary (Ex. images)
                // and one text attachment to a handled error report. 
                var properties = new Dictionary<string, string> {
                    { "Note", "Array problem" },
                    { "myNumbers", myNumbers.ToString() }
                  };

                Crashes.TrackError(exception, properties);
            }
        }

        private void Button_Clicked_Event(object sender, EventArgs e)
        {
            Analytics.TrackEvent("Button Event clicked");
        }

        int counter = 0;
        private void Button_Clicked_Event2(object sender, EventArgs e)
        {
            Analytics.TrackEvent("Button Event 2 clicked", new Dictionary<string, string> {
                { "Page", "MainPage" },
                { "CounterClick", counter++.ToString()}
            });
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            int[] myNumbers = { 1, 2, 3 };
            Console.WriteLine(myNumbers[10]); // Crash the app :(
        }
    }
}
