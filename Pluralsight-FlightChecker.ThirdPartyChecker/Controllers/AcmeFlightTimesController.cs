using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pluralsight_FlightChecker.Models;

namespace Pluralsight_FlightChecker.ThirdPartyChecker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcmeFlightTimesController : ControllerBase
    {
        private readonly ILogger<AcmeFlightTimesController> _logger;

        public AcmeFlightTimesController(ILogger<AcmeFlightTimesController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{requestedDateTicks}")]
        public async Task<FlightTimes> Get(long requestedDateTicks)
        {
            DateTime requestedDate = new DateTime(requestedDateTicks);
            var rng = new Random();

            // Simulate a slow service
            await Task.Delay(rng.Next(10) * 1000);

            DateTime departureTime = requestedDate.Date.AddHours(rng.Next(23));
            int duration = rng.Next(10) + 1;

            var flightTimes = Enumerable.Range(1, 5).Select(index => new FlightTime
            {
                DepartureDateTime = departureTime,
                FlightDuration = duration,
                ArrivalDateTime = departureTime.AddHours(duration),
                AllocatedSeatCount = rng.Next(401),
                CapacitySeats = 400,
                FlightNumber = $"AF{rng.Next(2000)}"
            })
            .ToList();

            return new FlightTimes()
            {
                FlightTimesData = flightTimes
            };
        }
    }
}
