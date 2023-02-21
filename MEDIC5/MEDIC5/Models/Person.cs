using System.ComponentModel.DataAnnotations;

namespace MEDIC5.Models
{
    public class Person
    {
        [Key]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string DateOfBirth { get; set; }
        public string Signature { get; set; }
    }
}