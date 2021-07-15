using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PotentialXTestAPI.Model;
using PotentialXTestAPI.Services;

namespace PotentialXTestAPI.Controllers
{
    [ApiController]
    public class PersonEventsController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly EventHubConfig _eventHubConfig;
        public PersonEventsController(IPersonService personService, IOptions<EventHubConfig> eventHubConfig)
        {
            _personService = personService;
            _eventHubConfig = eventHubConfig.Value;
        }

        [HttpGet]
        [Route("persons/events")]
        public IList<Event> Get(string firstName, string lastName, DateTime dob)
        {
            return _personService.GetEvents(firstName, lastName, dob);
        }

        [HttpPost]
        [Route("persons/events")]
        public async Task PostAsync(Event personEvent)
        {
            _personService.AddEvent(personEvent);

            HubConnection connection = new HubConnectionBuilder()
               .WithUrl(_eventHubConfig.EventHubUrl)
               .WithAutomaticReconnect()
               .Build();
            await connection.StartAsync();
            await connection.InvokeAsync("SendMessage", "Agent","Event added");
            return;
        }
    }
}
