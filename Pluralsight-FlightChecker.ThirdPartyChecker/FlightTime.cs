using System;

namespace Pluralsight_FlightChecker.ThirdPartyChecker
{
    public class FlightTime
    {
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public string FlightNumber { get; set; }
        public int CapacitySeats { get; set; }
        public int AllocatedSeatCount { get; set; }
        public int FlightDuration { get; set; }
    }
}
