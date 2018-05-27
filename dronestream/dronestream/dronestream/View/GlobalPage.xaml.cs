using dronestream.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static dronestream.Model.DroneStrike;

namespace dronestream.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GlobalPage : ContentPage
    {
        private Rootobject strikes; //= await DroneStreamManager.GetStrikes();

        public GlobalPage()
        {
            InitializeComponent();
            ShowGlobalInfo();

        }

        public async void ShowGlobalInfo()
        {
            loading.IsRunning = true;
            strikes = await DroneStreamManager.GetStrikes();
            loading.IsRunning = false;
            activityHolder.IsVisible = false;


            lblTotalDeaths.Text = Strike.TotalDeaths(strikes).ToString();
            lbldeathsPaki.Text = (Strike.TotalDeathsCountry(strikes, "Pakistan")+7).ToString(); // plus 7 Pakistan-Afghanistan Border
            lbldeathsYemen.Text = Strike.TotalDeathsCountry(strikes, "Yemen").ToString();
            lbldeathsSom.Text = Strike.TotalDeathsCountry(strikes, "Somalia").ToString();


            lblTotalchild.Text = Strike.TotalChildren(strikes).ToString();
            lblchildPaki.Text = Strike.TotalChildrenCountry(strikes, "Pakistan").ToString();
            lblchildYemen.Text = Strike.TotalChildrenCountry(strikes, "Yemen").ToString();
            lblchildSom.Text = Strike.TotalChildrenCountry(strikes, "Somalia").ToString();


            lblTotalinju.Text = Strike.TotalInjuries(strikes).ToString();
            lblinjuPaki.Text = Strike.TotalInjuriesCountry(strikes, "Pakistan").ToString();
            lblinjuYemen.Text = Strike.TotalInjuriesCountry(strikes, "Yemen").ToString();
            lblinjuSom.Text = Strike.TotalInjuriesCountry(strikes, "Somalia").ToString();


            lblTotalstrikes.Text = Strike.TotalStrikes(strikes).ToString();
            lblstrikesPaki.Text = Strike.TotalStrikesCountry(strikes, "Pakistan").ToString();
            lblstrikesYemen.Text = Strike.TotalStrikesCountry(strikes, "Yemen").ToString();
            lblstrikesSom.Text = Strike.TotalStrikesCountry(strikes, "Somalia").ToString();

            lblTotalTargets.Text = Strike.TotalTargets(strikes).ToString();
            lblTarPaki.Text = Strike.TotalTargetsCountry(strikes, "Pakistan").ToString();
            lblTarYem.Text = Strike.TotalTargetsCountry(strikes, "Yemen").ToString();
            lblTarSom.Text = Strike.TotalTargetsCountry(strikes, "Somalia").ToString();
            lbldate.Text += String.Format("{0:dd/MM/yy}", Strike.GetDate(strikes, true)) + " - " + String.Format("{0:dd/MM/yy}", Strike.GetDate(strikes, false));


        }





    }
}