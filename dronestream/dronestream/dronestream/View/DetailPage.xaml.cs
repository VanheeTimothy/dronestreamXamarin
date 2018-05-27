using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static dronestream.Model.DroneStrike;

namespace dronestream.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage(Strike s)
        {
            InitializeComponent();
            ShowDetails(s);

        }

        private void ShowDetails(Strike s)
        {
            SetCountryFlag(s);

            lblTown.Text = s.Town;
            lblDate.Text = string.Format("{0:dd/MM/yy}", s.Date);
            lblLocation.Text = s.Location;
            lblLat.Text = s.Lat;
            lblLon.Text = s.Lon;
            lblCountry.Text = s.Country;


            if (s.Deaths == "" || s.Deaths == null)
            {
                xDeaths.IsVisible = false;
                lblDeaths.IsVisible = false;
            }
            else
            {
                lblDeaths.Text = s.Deaths;
            }

            if (s.Injuries == "" || s.Injuries == null)
            { 
                xInjuries.IsVisible = false;
                lblInjuries.IsVisible = false;
            }
            else
            {
                lblInjuries.Text = s.Injuries;
            }



            if (s.Civilians == null || s.Civilians == "")
            {
                xCivilians.IsVisible = false;
                lblCivilians.IsVisible = false;
            }
            else
            {
                lblCivilians.Text = s.Civilians;
            }
            if (s.Children == null || s.Children == "")
            {
                xChildren.IsVisible = false;
                lblChildren.IsVisible = false;
            }
            else
            {
                lblChildren.Text = s.Children;

            }
            if (s.Target == null || s.Target == "")
            {
                xTarget.IsVisible = false;
                lblTarget.IsVisible = false;
            }
            else
            {
                List<string> targets = new List<string>();
                try
                {
                    foreach (string target in s.Target.Split(';'))
                    {
                        targets.Add(target);



                    }
                    
                    foreach (string elm in targets)
                    {
                        lblTarget.Text += elm.Trim() + "\n";

                    }



                }
                catch (Exception ex)
                {
                    Debug.WriteLine("NOOOOOOOOOOOOOOOOOOOOOO not again: " + ex);
                }



            }

            if (s.Names == null || s.Names.Contains(""))
            {
                xNames.IsVisible = false;
                lblNames.IsVisible = false;
            }
            else
            {
                List<string> names = new List<string>();

                foreach (string name in s.Names)
                {
                    Debug.WriteLine("----: " + name + " :------");
                    string[] Rightname = name.Split(',');
                    foreach (string elm in Rightname)
                    {
                        names.Add(elm);
                    }

                }


                foreach (string elm in names)
                {
                    lblNames.Text += elm.Trim() + "\n";
                }

            }
            if (s.Narrative == "" || s.Narrative == null)
            {
                xNarrative.IsVisible = false;
                lblNarrative.IsVisible = false;
            }
            else
            {
                lblNarrative.Text = s.Narrative;

            }









        }


        private void SetCountryFlag(Strike s)
        {
            string ResourceID = "dronestream.Assets.USdrone.jpg";
            switch (s.Country)
            {
                case "Yemen":
                    ResourceID = "dronestream.Assets.1280px-Flag_of_Yemen.jpg";
                    lblTown.TextColor = Color.FromHex("#900200");
                    lblDate.TextColor = Color.FromHex("#900200");
                    lblLocation.TextColor = Color.FromHex("#900200");
                    lblCountry.TextColor = Color.FromHex("#900200");
                    lblLat.TextColor = Color.FromHex("#900200");
                    lblLon.TextColor = Color.FromHex("#900200");
                    lblChildren.TextColor = Color.FromHex("#900200");
                    lblCivilians.TextColor = Color.FromHex("#900200");
                    lblDeaths.TextColor = Color.FromHex("#900200");
                    lblInjuries.TextColor = Color.FromHex("#900200");
                    lblNames.TextColor = Color.FromHex("#900200");
                    lblNarrative.TextColor = Color.FromHex("#900200");
                    lblTarget.TextColor = Color.FromHex("#900200");



                    break;
                case "Somalia":
                    ResourceID = "dronestream.Assets.somalia.jpg";
                    lblTown.TextColor = Color.FromHex("#3f8ade");
                    lblDate.TextColor = Color.FromHex("#3f8ade");
                    lblLocation.TextColor = Color.FromHex("#3f8ade");
                    lblCountry.TextColor = Color.FromHex("#3f8ade");
                    lblLat.TextColor = Color.FromHex("#3f8ade");
                    lblLon.TextColor = Color.FromHex("#3f8ade");
                    lblChildren.TextColor = Color.FromHex("#3f8ade");
                    lblCivilians.TextColor = Color.FromHex("#3f8ade");
                    lblDeaths.TextColor = Color.FromHex("#3f8ade");
                    lblInjuries.TextColor = Color.FromHex("#3f8ade");
                    lblNames.TextColor = Color.FromHex("#3f8ade");
                    lblNarrative.TextColor = Color.FromHex("#3f8ade");
                    lblTarget.TextColor = Color.FromHex("#3f8ade");
                    break;
                default:
                    ResourceID = "dronestream.Assets.pakistanflag.jpg";
                    lblTown.TextColor = Color.FromHex("#01411c");
                    lblDate.TextColor = Color.FromHex("#01411c");
                    lblLocation.TextColor = Color.FromHex("#01411c");
                    lblCountry.TextColor = Color.FromHex("#01411c");
                    lblLat.TextColor = Color.FromHex("#01411c");
                    lblLon.TextColor = Color.FromHex("#01411c");
                    lblChildren.TextColor = Color.FromHex("#01411c");
                    lblCivilians.TextColor = Color.FromHex("#01411c");
                    lblDeaths.TextColor = Color.FromHex("#01411c");
                    lblInjuries.TextColor = Color.FromHex("#01411c");
                    lblNames.TextColor = Color.FromHex("#01411c");
                    lblNarrative.TextColor = Color.FromHex("#01411c");
                    lblTarget.TextColor = Color.FromHex("#01411c");
                    break;
            }
            CountryFlag.Source = ImageSource.FromResource(ResourceID);



        }
    }
}