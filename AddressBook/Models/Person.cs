using System.ComponentModel.DataAnnotations;

namespace AddressBook.Models
{
    public class Person
    {
        public int Id { get; set; }
      
        [MaxLength(50)]
        public string FirstName { get; set; }
      
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(250)]
        [EmailAddress]
        public string Email { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}