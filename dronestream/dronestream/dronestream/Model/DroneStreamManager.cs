using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static dronestream.Model.DroneStrike;

namespace dronestream.Model
{
    public class DroneStreamManager
    {
        //methode 1: downloaden van de verschillende DroneStrikes
        public async static Task<Rootobject> GetStrikes()
        {
            string url = "https://api.dronestre.am/data";
            // verbinding met API wordt via HttpClient verzorgd >> aanmaken HttpClient
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            string result = await client.GetStringAsync(url);
            Rootobject strikes = JsonConvert.DeserializeObject<Rootobject>(result);
            foreach (Strike s in strikes.Strike)
            {

                if (s.Town == "" || s.Town == " " || s.Town == null)
                {
                    s.Town = "Unknown";

                }

            }
            return strikes;
        }
    }
}