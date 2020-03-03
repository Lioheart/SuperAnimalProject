using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAnimal.Models
{
    public class Pet
    {
        [Key]
        public int PetId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Breed { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DeathDate { get; set; }
        public string Description { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public string UserId { get; set; }

        public virtual ICollection<MotherPet> MotherPets { get; set; }
        public virtual ICollection<FatherPet> FatherPets { get; set; }
    }

    public class MotherPet
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("PetId")]
        public Pet Pet { get; set; }
        public int PetId { get; set; }
    }

    public class FatherPet
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("PetId")]
        public Pet Pet { get; set; }
        public int PetId { get; set; }
    }
}
