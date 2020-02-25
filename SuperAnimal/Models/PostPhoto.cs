using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAnimal.Models
{
    public class PostPhoto
    {
        public int PostPhotoId { get; set; }
        public string Image { get; set; }

        public virtual Post Post { get; set; }
    }
}
