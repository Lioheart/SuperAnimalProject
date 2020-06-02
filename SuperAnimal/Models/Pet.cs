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
        public int Id { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public string Breed { get; set; }

        public string ProfilePhoto { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? DeathDate { get; set; }

        public string Description { get; set; }

        public Sex Sex { get; set; }

        public AppUser User { get; set; }

        public string UserId { get; set; }

        [ForeignKey("MotherId")]
        public Pet Mother { get; set; }

        [ForeignKey("FatherId")]
        public Pet Father { get; set; }


    }

}
