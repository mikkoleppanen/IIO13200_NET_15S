using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava7
{
    class Train
    {
        public String trainNumber { get; set; }
        public DateTime departureDate { get; set; }
        public bool cancelled { get; set; }
        public List<Times> timeTableRows { get; set; }
    }
    class Station
    {
        public String stationName { get; set; }
        public String stationShortCode { get; set; }
    }

    class Times
    {
        public DateTime scheduledTime { get; set; }
        public String type { get; set; }
        public String stationShortCode { get; set; }
    }
    class BetterTrain
    {
        public String trainNumber { get; set; }
        public String scheduledTime { get; set; }
        public bool cancelled { get; set; }
    }
}
