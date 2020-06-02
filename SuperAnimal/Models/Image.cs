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
        public int Id { get; set; }

        public string Photo { get; set; }

        public Pet Pet { get; set; }

    }
}
