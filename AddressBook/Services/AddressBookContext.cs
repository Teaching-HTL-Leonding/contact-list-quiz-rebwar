using AddressBook.Models;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Services
{
    public class AddressBookContext:DbContext{
        public AddressBookContext(DbContextOptions<AddressBookContext> options):base(options)
        {
            
        }
        public DbSet<Person> People { get; set; }
    }
}