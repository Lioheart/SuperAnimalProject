using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAnimal.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Body { get; set; }
        public DateTime Timestamp { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<PostPhoto> PostPhotos { get; set; }
    }
}
