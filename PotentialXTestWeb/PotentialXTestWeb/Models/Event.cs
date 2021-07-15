using System;

namespace PotentialXTestWeb.Models
{
    public class Event
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
