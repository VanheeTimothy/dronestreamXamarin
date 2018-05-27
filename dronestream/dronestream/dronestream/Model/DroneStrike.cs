using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dronestream.Model
{
    public class DroneStrike
    
   {


       public class Rootobject
        {
            //[JsonProperty(PropertyName = "status")]
            public string Status { get; set; }
            //[JsonProperty(PropertyName = "strike")]
            public Strike[] Strike { get; set; }
        }

        public class Strike
        {
            //[JsonProperty(PropertyName = "_id")]
            public string _id { get; set; }

            //[JsonProperty(PropertyName = "number")]
            public int Number { get; set; }

            //[JsonProperty(PropertyName = "country")]
            public string Country { get; set; }

            //[JsonProperty(PropertyName = "date")]
            public DateTime Date { get; set; }

            //[JsonProperty(PropertyName = "narrative")]
            public string Narrative { get; set; }

            //[JsonkProperty(PropertyName = "town")]
            public string Town { get; set; }

            //[JsonProperty(PropertyName = "location")]
            public string Location { get; set; }

            //[JsonProperty(PropertyName = "deaths")]
            public string Deaths { get; set; }

            //[JsonProperty(PropertyName = "deaths_min")]
            public string Deaths_min { get; set; }

            //[JsonProperty(PropertyName = "deaths_max")]k
            public string Deaths_max { get; set; }

            //[JsonProperty(PropertyName = "civilians")]
            public string Civilians { get; set; }

            //[JsonProperty(PropertyName = "injuries")]
            public string Injuries { get; set; }

            //[JsonProperty(PropertyName = "children")]
            public string Children { get; set; }

            //[JsonProperty(PropertyName = "tweet_id")]
            public string Tweet_id { get; set; }

            //[JsonProperty(PropertyName = "bureau_id")]
            public string Bureau_id { get; set; }

            //[JsonProperty(PropertyName = "bij_summary_short")]
            public string Bij_summary_short { get; set; }

            //[JsonProperty(PropertyName = "bij_link")]
            public string Bij_link { get; set; }

            //[JsonProperty(PropertyName = "target")]
            public string Target { get; set; }

            //[JsonProperty(PropertyName = "lat")]
            public string Lat { get; set; }

            //[JsonProperty(PropertyName = "lon")]
            public string Lon { get; set; }

            //[JsonProperty(PropertyName = "articles")]
            public object[] Articles { get; set; }

            //[JsonProperty(PropertyName = "names")]
            public string[] Names { get; set; }





            //methode 1: filteren op Land   >> wordt gebruikt bij de picker
            public static List<Strike> GetStrikesByCountry(Rootobject Strikes, string country)
            {
                List<Strike> GefilterdeStrikes = new List<Strike>();
                foreach (Strike S in Strikes.Strike)
                {
                    if (S.Country.ToLower() == country.ToLower())
                    {
                        GefilterdeStrikes.Add(S);
                       // Debug.WriteLine("DroneStrike in " + S.Country + " op locatie: " + S.Location + " aantal doden: " + S.Deaths_max);
                    }
                }
                return GefilterdeStrikes;

            }

            // elke country in een list opslaan en deze doorgeven aan de pickerCountry
            public static List<string> GetUniqueCountry(Rootobject Strikes)
            {
                List<string> UniqueCountry = new List<string>();
                foreach (Strike s in Strikes.Strike)
                {
                    if (!UniqueCountry.Contains(s.Country))
                    {
                        UniqueCountry.Add(s.Country);

                    }

                }
                return UniqueCountry;
            }




            //onderstaande methoden dienen voor een totaalbeeld te geven op de GlobalPage
            //methode: totaal aantal doden
            public static int TotalDeaths(Rootobject Strikes)
            {
                try
                {
         
                    int total_deaths = 0;
                    foreach (Strike S in Strikes.Strike)
                    {

                        if (S.Deaths_max != null && S.Deaths_max != "" && S.Deaths_max != "?") //foutieve waarden uithalen
                        {
                            int n = Convert.ToInt32(S.Deaths_max);
                            total_deaths += n;
                        }
                    }

                    return total_deaths;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            public static int TotalDeathsCountry(Rootobject Strikes, string country)
            {
                try
                {
                    int total_deaths = 0;
                    foreach (Strike S in Strikes.Strike)
                    {
                        if (S.Country.ToLower() == country.ToLower())
                        {
                            if (S.Deaths_max != null && S.Deaths_max != "" && S.Deaths_max != "?") //foutieve waarden uithalen
                            {
                                int n = Convert.ToInt32(S.Deaths_max);
                                total_deaths += n;
                            }
                        }

                    }

                    return total_deaths;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }


            //methode om totaal # gewonden op te vragen
            public static int TotalInjuries(Rootobject Strikes)
            {
                int totalInjuries = 0;
                foreach (Strike s in Strikes.Strike)
                {
                    if (int.TryParse(s.Injuries, out int number))
                    {
                        totalInjuries += number;
                    }

                }
                return totalInjuries;
            }

            public static int TotalInjuriesCountry(Rootobject Strikes, string country)
            {
                int totalInjuries = 0;
                foreach (Strike s in Strikes.Strike)
                {
                    if (s.Country.ToLower() == country.ToLower())
                    {
                        if (int.TryParse(s.Injuries, out int number))
                        {
                            totalInjuries += number;
                        }
                    }


                }
                return totalInjuries;
            }


            //methode om total #strikes op te vragen
            public static int TotalStrikes(Rootobject Strikes)
            {
                int totalStrikes = 0;
                foreach (Strike s in Strikes.Strike)
                {
                    Debug.WriteLine(s.Town);
                    totalStrikes++;
                    Debug.WriteLine(totalStrikes);
                }
                return totalStrikes;
            }

            public static int TotalStrikesCountry(Rootobject Strikes, string country)
            {
                int totalStrikes = 0;

                foreach (Strike s in Strikes.Strike)
                {
                    if (s.Country.ToLower() == country.ToLower())
                    {
                        totalStrikes++;
                    }

                }
                return totalStrikes;
            }






            //methode om # children op te vragen
            public static int TotalChildren(Rootobject Strikes)
            {
                int totalChildren = 0;
                foreach (Strike s in Strikes.Strike)
                {
                    if (int.TryParse(s.Children, out int number))
                    {
                        totalChildren += number;
                    }

                }
                return totalChildren;
            }



            public static int TotalChildrenCountry(Rootobject Strikes, string country)
            {
                int totalChildren = 0;
                foreach (Strike s in Strikes.Strike)
                {
                    if (s.Country.ToLower() == country.ToLower())
                    {
                        if (int.TryParse(s.Children, out int number))
                        {
                            totalChildren += number;
                        }
                    }

                }

                return totalChildren;
            }

            public static int TotalTargets(Rootobject Strikes)
            {
                int n = 0;
                List<string> targets = new List<string>();
                try
                {
                    foreach (Strike s in Strikes.Strike)
                    {
                        foreach (string target in s.Target.Split(';'))
                        {
                            if (target != "")
                            {
                                targets.Add(target);
                               
                            }
                        }

                    }
                    foreach (string elm in targets)
                    {
                        n++;
                      //  Debug.WriteLine(n + ":" + elm);


                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                return n;
            }

            public static int TotalTargetsCountry(Rootobject Strikes, string country)
            {
                int n = 0;
                List<string> targets = new List<string>();
                try
                {
                    foreach (Strike s in Strikes.Strike)
                    {
                        if (s.Country.ToLower() == country.ToLower())
                        {
                            foreach (string target in s.Target.Split(';'))
                            {
                                if(target != "")
                                {
                                    targets.Add(target);
                   
                                }
                               
                            }
                        }
                    }

                    foreach (string elm in targets)
                    {
                        n++;
                       // Debug.WriteLine(n + ":" + elm);


                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                return n;
            }

            //methode om jongste en oudste datum terug te geven
            public static DateTime GetDate(Rootobject strikes, bool youngestDate)
            {
                List<DateTime> date = new List<DateTime>();
                foreach (Strike s in strikes.Strike)
                {
                    date.Add(s.Date);
                }
                if (youngestDate == true)
                {

                    return date.Min();
                }
                else
                {
                    return date.Max();
                }

            }




            //methode die bepaald welk land 't meeste strikes gekend heeft
            // return # strikes + string NameCountry
            public static KeyValuePair<int, string> GetMostStrikesOnWinningCountry(Rootobject Strikes)
            {

                int totalPakistan = 0;
                int totalYemen = 0;
                int totalSomalia = 0;
                int other = 0;
                foreach (Strike s in Strikes.Strike)
                {
                    switch (s.Country)
                    {
                        case "Pakistan":
                            totalPakistan++;
                            break;
                        case "Yemen":
                            totalYemen++;
                            break;
                        case "Somalia":
                            totalSomalia++;
                            break;
                        default:
                            other++;
                            break;
                    }

                }


                if (totalPakistan > totalYemen && totalPakistan > totalSomalia && totalPakistan > other)
                {
                    var KeyValuePair = new KeyValuePair<int, string>(totalPakistan, "Pakistan");
                    return KeyValuePair;
                }
                else if (totalYemen > totalPakistan && totalYemen > totalSomalia && totalYemen > other)
                {
                    var KeyValuePair = new KeyValuePair<int, string>(totalYemen, "Yemen");
                    return KeyValuePair;

                }
                else if (totalSomalia > totalPakistan && totalSomalia > totalYemen && totalSomalia > other)
                {
                    var KeyValuePair = new KeyValuePair<int, string>(totalSomalia, "Somalia");
                    return KeyValuePair;

                }
                else
                {
                    var KeyValuePair = new KeyValuePair<int, string>(other, "other");
                    return KeyValuePair;

                }


            }



        }






    }
}

