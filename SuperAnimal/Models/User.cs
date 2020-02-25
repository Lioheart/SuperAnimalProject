using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAnimal.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }

        // Do jednego użytkownika możemy przypisać wiele postów
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
