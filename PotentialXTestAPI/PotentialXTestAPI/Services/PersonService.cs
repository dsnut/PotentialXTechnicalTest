using Newtonsoft.Json;
using PotentialXTestAPI.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PotentialXTestAPI.Services
{
    public class PersonService : IPersonService
    {
        public IList<Event> GetEvents(string firstname, string lastname, DateTime dob)
        {
            IList<Event> events = null;
            using (StreamReader r = new StreamReader(@"Datastore\events.json"))
            {
                string json = r.ReadToEnd();
                events = JsonConvert.DeserializeObject<IList<Event>>(json);
                events = events.Where(e => e.FirstName == firstname && e.LastName == lastname && e.DateOfBirth == dob).ToList();
            }
            return events;
        }

        public IList<Person> GetPersons()
        {
            IList<Person> persons = null;
            using (StreamReader r = new StreamReader(@"Datastore\persons.json"))
            {
                string json = r.ReadToEnd();
                persons = JsonConvert.DeserializeObject<IList<Person>>(json);
            }
            return persons;
        }
        public void AddEvent(Event personEvent)
        {
            IList<Event> events = null;
            using (StreamReader r = new StreamReader(@"Datastore\events.json"))
            {
                string json = r.ReadToEnd();
                events = JsonConvert.DeserializeObject<IList<Event>>(json);
            }
            events.Add(personEvent);
            using (StreamWriter r = new StreamWriter(@"Datastore\events.json",false))
            {
                r.Write(JsonConvert.SerializeObject(events));
            }
        }
    }
}
