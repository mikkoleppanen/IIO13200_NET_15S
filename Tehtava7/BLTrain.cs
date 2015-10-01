using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava7
{
    class BLTrain
    {
        private String json = "";
        public List<Train> GetTrains(String stationCode)
        {
            //Haetaan Json
            String url = "http://rata.digitraffic.fi/api/v1/live-trains?station=" + stationCode;
            json = GetJsonFromWeb(url);
            //Muunnetaan se olioksi
            List<Train> trains = JsonConvert.DeserializeObject<List<Train>>(json);
            //Näytetään UI:ssa
            //txtJSON.Text = json;
            return trains;
        }

        private String GetJsonFromWeb(String url)
        {
            try
            {
                //using vapauttaa muistin sulkeiden lopussa
                using (WebClient wc = new WebClient())
                {
                    return wc.DownloadString(url);
                }
            }
            catch (Exception)
            {
                //throw;
            }
            return "Homo";
        }

        public List<Station> GetStations()
        {
            String url = "http://rata.digitraffic.fi/api/v1/metadata/station";
            json = GetJsonFromWeb(url);
            List<Station> stations = JsonConvert.DeserializeObject<List<Station>>(json);
            return stations;
        }
    }
}
