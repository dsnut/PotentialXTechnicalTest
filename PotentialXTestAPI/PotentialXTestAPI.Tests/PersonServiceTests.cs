using PotentialXTestAPI.Services;
using System;
using Xunit;

namespace PotentialXTestAPI.Tests
{
    public class PersonServiceTests
    {
        private IPersonService _personService;

        [Fact]
        public void GetPerson_ShouldGetPersons()
        {
            //Arrange
            _personService = new PersonService();

            //Act
            var result = _personService.GetPersons();

            //Assert
            Assert.True(result.Count > 0);
        }

        [Fact]
        public void GetEvents_ShouldGetPersonEvents()
        {
            //Arrange
            _personService = new PersonService();
            var firstName = "Bruce";
            var lastName = "Wayne";
            var dob = new DateTime(01, 01, 1960);

            //Act
            var result = _personService.GetEvents(firstName, lastName, dob);

            //Assert
            Assert.True(result.Count > 0);
        }
    }
}
