using Microsoft.AspNetCore.Mvc;
using PotentialXTestAPI.Model;
using PotentialXTestAPI.Services;
using System.Collections.Generic;

namespace PotentialXTestAPI.Controllers
{
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("")]
        public IList<Person> Get()
        {
            return _personService.GetPersons();
        }
    }
}
