using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAnimal.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public string Photo { get; set; }
        public virtual Pet Pet { get; set; }

    }
}
