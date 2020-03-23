using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAnimal.ViewModels.Pet
{
    public class AddPetViewModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public IFormFile ProfilePhoto { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
