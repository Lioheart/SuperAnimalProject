using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAnimal.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }
        public string Photo { get; set; }

        [ForeignKey("PetId")]
        public Pet Pet { get; set; }
        public int PetId { get; set; }

    }
}
