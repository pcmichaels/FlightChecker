using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Pluralsight_FlightChecker.ThirdPartyChecker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcmeFlightController : ControllerBase
    {
        private readonly ILogger<AcmeFlightController> _logger;

        public AcmeFlightController(ILogger<AcmeFlightController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<FlightTime>> Get(DateTime requestedDate)
        {
            var rng = new Random();

            // Simulate a slow service
            await Task.Delay(rng.Next(60) * 1000);

            DateTime departureTime = requestedDate.Date.AddHours(rng.Next(23));
            int duration = rng.Next(10) + 1;

            return Enumerable.Range(1, 5).Select(index => new FlightTime
            {
                DepartureDateTime = departureTime,
                FlightDuration = duration,
                ArrivalDateTime = departureTime.AddHours(duration),
                AllocatedSeatCount = rng.Next(401),
                CapacitySeats = 400,
                FlightNumber = $"AF{rng.Next(2000)}"
            })
            .ToArray();
        }
    }
}
