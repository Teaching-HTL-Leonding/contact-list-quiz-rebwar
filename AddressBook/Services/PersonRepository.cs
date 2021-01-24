using System.Collections.Generic;
using System.Linq;
using AddressBook.Models;

namespace AddressBook.Services
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AddressBookContext context;

        public PersonRepository(AddressBookContext context)
        {
            this.context = context;
        }
        public Person AddPerson(Person person)
        {
            context.People.Add(person);
            context.SaveChanges();
            return person;
        }

        public bool DeletePerson(int personId)
        {
            var person = context.People.FirstOrDefault(p => p.Id == personId);
            if (person != null)
            {
                person.IsDeleted = true;
                context.People.Update(person);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Person FindPersonByName(string nameFilter)
        {
            var person = context.People.Where(t => t.IsDeleted == false).FirstOrDefault(p => p.FirstName == nameFilter);
            if (person != null)
            {
                return person;
            }
            return null;
        }

        public IEnumerable<Person> GetAllPeople() => context.People.Where(c => c.IsDeleted == false).ToList();

        public Person UpdatePerson(int personId, Person person)
        {
            var personItem = context.People.Where(t => t.IsDeleted == false).FirstOrDefault(p => p.Id == personId);
            if (personItem != null)
            {
                context.People.Update(personItem);
                context.SaveChanges();
                return personItem;
            }
            return null;
        }
    }
}