using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAnimal.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime DateTime { get; set; }


        [ForeignKey("User")]
        public string UserId { get; set; }

        public AppUser User { get; set; }

        [ForeignKey("Chat")]
        public string ChatId { get; set; }

        public Chat Chat { get; set; }
    }
}
