using dronestream.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static dronestream.Model.DroneStrike;

namespace dronestream.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoSPage : ContentPage
    {
        private Rootobject strikes; //= await DroneStreamManager.GetStrikes();

        public LoSPage()
        {
            InitializeComponent();
            ListStrikes();
        }

        public async void ListStrikes()
        {

            loading.IsRunning = true;
            strikes = await DroneStreamManager.GetStrikes();
            loading.IsRunning = false;
            activityHolder.IsVisible = false;


            IOrderedEnumerable<Strike> SortedStrikes = strikes.Strike.OrderBy(item => item.Date);

            lvwStrikes.ItemsSource = SortedStrikes;
            pickCountry.ItemsSource = Strike.GetUniqueCountry(strikes);

        }

        private void lvwStrikes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Strike s = lvwStrikes.SelectedItem as Strike;

            if (s != null)
            {
                Navigation.PushAsync(new DetailPage(lvwStrikes.SelectedItem as Strike));
                lvwStrikes.SelectedItem = null;
            }


        }

        private async void pickCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

            lvwStrikes.ItemsSource = Strike.GetStrikesByCountry(strikes, pickCountry.SelectedItem.ToString());

        }
    }
}