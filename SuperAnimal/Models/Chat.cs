using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAnimal.Models
{
    public class Chat
    {
        [Key]
        public string Id { get; set; }

        public DateTime StartDateTime { get; set; }


        public ICollection<Message> Messages { get; set; }

        [ForeignKey("StartUser")]
        public string StartUserId { get; set; }

        public AppUser StartUser { get; set; }

        [ForeignKey("SecondUser")]
        public string SecondUserId { get; set; }

        public AppUser SecondUser { get; set; }

    }
}
