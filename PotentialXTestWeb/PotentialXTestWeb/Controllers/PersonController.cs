using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PotentialXTestWeb.Models;
using PotentialXTestWeb.Models.Config;

namespace PotentialXTestWeb.Controllers
{
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly PersonEventSourceConfig _personEventSourceConfig;
        private HttpClient _httpClient;

        public PersonController(ILogger<PersonController> logger, IOptions<PersonEventSourceConfig> personEventSourceConfig, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _personEventSourceConfig = personEventSourceConfig.Value;
            _httpClient = clientFactory.CreateClient();
        }

        public async Task<IActionResult> Index()
        {
            var configRequest = new HttpRequestMessage(HttpMethod.Get, _personEventSourceConfig.PersonsUrl);
            var resp = await _httpClient.SendAsync(configRequest).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<IList<Person>>(await resp.Content.ReadAsStringAsync());
            return View(result);
        }

        public async Task<IActionResult> Events(string firstName, string lastName, DateTime dob)
        {
            var eventsURL = string.Format(_personEventSourceConfig.PersonEventsUrl, firstName, lastName, dob);
            var configRequest = new HttpRequestMessage(HttpMethod.Get, eventsURL);
            var resp = await _httpClient.SendAsync(configRequest).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<IList<Event>>(await resp.Content.ReadAsStringAsync());
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
