using Pluralsight_FlightChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pluralsight_FlightChecker.WebApp.Models
{
    public class CheckTimesViewModel
    {
        public IEnumerable<FlightTime> FlightTimes { get; set; }


    }
}
