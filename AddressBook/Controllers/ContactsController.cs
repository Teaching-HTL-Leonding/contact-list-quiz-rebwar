using System.Collections.Generic;
using System.Linq;
using AddressBook.Models;
using AddressBook.Services;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    [ApiController]
    [Route("api/contact")]
    public class ContactController : ControllerBase
    {
        private readonly IPersonRepository repository;


        public ContactController(IPersonRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAllPeople() => repository.GetAllPeople().ToList();

        [HttpGet("{firstname}",Name="FindPersonByName")]
        public ActionResult<Person> FindPersonByName(string firstname)
        {
            var person = repository.FindPersonByName(firstname);
            if (person != null)
            {
                return Ok(person);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]

        public ActionResult<Person> AddPerson(Person person)
        {
            var AddedPerson = repository.AddPerson(person);
            return CreatedAtAction(nameof(FindPersonByName),new Person{FirstName=AddedPerson.FirstName}, AddedPerson);
        }

        [HttpPut("{personId}")]
        public ActionResult<Person> UpdatePerson(int personId, Person person)
        {
            var updatedPerson = repository.UpdatePerson(personId, person);
            if (updatedPerson != null)
            {
                return Ok(person);
            }
            return NotFound();
        }

        [HttpDelete("personId")]
        public ActionResult<Person> DeletePerson(int personId)
        {
            var deletedPerson = repository.DeletePerson(personId);
            if (deletedPerson)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}