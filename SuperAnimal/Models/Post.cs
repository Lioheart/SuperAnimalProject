using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAnimal.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public AppUser User { get; set; }

        public string UserId { get; set; }

        public string Body { get; set; }

        public DateTime? Timestamp { get; set; }


    }
}
