using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pluralsight_FlightChecker.WebApp.Models
{
    public class HomeViewModel
    {
        [DataType(DataType.Date)]
        public DateTime FlightDate { get; set; }
    }
}
