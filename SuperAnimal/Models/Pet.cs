using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAnimal.Models
{
    public class Pet
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Breed { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DeathDate { get; set; }
        public string Description { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<MotherPet> MotherPets { get; set; }
        public virtual ICollection<FatherPet> FatherPets { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }

    public class MotherPet
    {
        public int PetId { get; set; }
        public virtual Pet Pet { get; set; }
    }

    public class FatherPet
    {
        public int PetId { get; set; }
        public virtual Pet Pet { get; set; }
    }
}
