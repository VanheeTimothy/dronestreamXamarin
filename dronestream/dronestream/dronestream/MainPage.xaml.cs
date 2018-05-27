using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace dronestream
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            TapGesture();
            TapGestureGlobalPage();
            TapGestureWeb();
            string ResourceID = "dronestream.Assets.USdrone.jpg";
            imgBackground.Source = ImageSource.FromResource(ResourceID);





        }
        private void TapGesture()
        {
            TapGestureRecognizer ges = new TapGestureRecognizer();
            ges.Tapped += Ges_Tapped;
            lblList.GestureRecognizers.Add(ges);
        }

        private void TapGestureGlobalPage()
        {
            TapGestureRecognizer ges = new TapGestureRecognizer();
            ges.Tapped += Ges_GlobalPage;
            lblGlobalinfo.GestureRecognizers.Add(ges);

        }

        private void TapGestureWeb()
        {
            TapGestureRecognizer ges = new TapGestureRecognizer();
            ges.Tapped += Ges_Website;
            lblUrl.GestureRecognizers.Add(ges);
        }

        private void Ges_Website(object sender, EventArgs e)
        {
            

            Device.OpenUri(new Uri("https://api.dronestre.am/search"));
        }

        private void Ges_GlobalPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new dronestream.View.GlobalPage());
        }

        private void Ges_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new dronestream.View.LoSPage());

        }
    }
}

