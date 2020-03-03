using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAnimal.Models
{
    public class PostPhoto
    {
        [Key]
        public int PostPhotoId { get; set; }
        public string Image { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }
        public int PostId { get; set; }
    }
}
