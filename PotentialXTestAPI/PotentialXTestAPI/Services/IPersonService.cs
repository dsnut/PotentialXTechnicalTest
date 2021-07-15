using PotentialXTestAPI.Model;
using System;
using System.Collections.Generic;

namespace PotentialXTestAPI.Services
{
    public interface IPersonService
    {
        IList<Person> GetPersons();
        IList<Event> GetEvents(string firstname, string lastname, DateTime dob);

        void AddEvent(Event personEvent);
    }
}
