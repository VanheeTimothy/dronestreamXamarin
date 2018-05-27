using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace dronestream
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //try
            //{
            MainPage = new NavigationPage(CrossConnectivity.Current.IsConnected ? (Page)new dronestream.MainPage() : new dronestream.View.NoNetworkPage());

            //}
            //catch(Exception ex)
            //{
            //    Debug.WriteLine("########################################");
            //    Debug.WriteLine("Tell me more, Tell me more; LaLaLaLaLa");
            //    Debug.WriteLine("########################################");
            //}


            //MainPage = new NavigationPage(new dronestream.MainPage());
        }

        protected override void OnStart()
        {
            base.OnStart();
            CrossConnectivity.Current.ConnectivityChanged += HandleConnectivityChanged;

        }
        void HandleConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            try
            {
                Type currentPage = this.MainPage.GetType();
                if (e.IsConnected && currentPage != typeof(dronestream.MainPage))
                    this.MainPage = new dronestream.MainPage();
                else if (!e.IsConnected && currentPage != typeof(dronestream.View.NoNetworkPage))
                    this.MainPage = new dronestream.View.NoNetworkPage();
            }
            catch(Exception ex)
            {
                Debug.WriteLine("########################################");
                Debug.WriteLine("Tell me more, Tell me more; LaLaLaLaLa");
                Debug.WriteLine("########################################");

                Debug.WriteLine(ex);
            }
          
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
