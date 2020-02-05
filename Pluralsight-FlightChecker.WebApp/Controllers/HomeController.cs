using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pluralsight_FlightChecker.Models;
using Pluralsight_FlightChecker.WebApp.Models;

namespace Pluralsight_FlightChecker.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(ILogger<HomeController> logger,
            IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> CheckTimes(HomeViewModel viewModel)
        {
            var client = _clientFactory.CreateClient();

            var date = viewModel.FlightDate;
            long dateTicks = date.Ticks;
            var result = await client.GetAsync($"https://localhost:44309/acmeflighttimes/{dateTicks}");

            using var responseStream = await result.Content.ReadAsStreamAsync();
            var responseString = await result.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var flightTimes = await JsonSerializer.DeserializeAsync<FlightTimes>(responseStream, options);

            var checkTimesViewModel = new CheckTimesViewModel()
            {
                FlightTimes = flightTimes.FlightTimesData
            };
            return View(checkTimesViewModel);
        }
    }
}
