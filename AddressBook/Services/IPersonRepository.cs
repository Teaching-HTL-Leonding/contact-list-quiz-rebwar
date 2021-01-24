using System.Collections.Generic;
using AddressBook.Models;

namespace AddressBook.Services
{
    public interface IPersonRepository{
        IEnumerable<Person> GetAllPeople();
        Person AddPerson(Person person);
        bool DeletePerson(int personId);
        Person FindPersonByName(string nameFilter);
        Person UpdatePerson(int personId,Person person);

    }

}