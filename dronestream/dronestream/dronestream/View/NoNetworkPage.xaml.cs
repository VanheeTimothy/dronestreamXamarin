using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dronestream.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoNetworkPage : ContentPage
    {
        public NoNetworkPage()
        {
            BackgroundColor = Color.FromHex("#29364A");
            Content = new Label()
            {
                Text = "No Network Connection Available. \n You know what to do :)",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex("#D5AFA5"),
                FontSize = 20

            };
            try
            {
                string ResourceID = "dronestream.Assets.nonetwork.png";
                Photo.Source = ImageSource.FromResource(ResourceID);
                Photo = new Image()
                {
                    InputTransparent = true,
                    Aspect = Aspect.Fill,
                    Scale = 0.95,
                    Source = ImageSource.FromResource("dronestream.Assets.nonetwork.png")
                };
            }
            catch(Exception ex)
            {
                Debug.WriteLine("########################################");
                Debug.WriteLine("Tell me more, Tell me more; LaLaLaLaLa");
                Debug.WriteLine("########################################");

                Debug.WriteLine(ex);
            }

        }
    }
}