using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAnimal.ViewModels.Deal
{
    public class DealIndexViewModel
    {
        [Display(Name = "Pet Name")]
        public string SearchedPetName { get; set; }

        public List<Models.Pet> Pets { get; set; } = new List<Models.Pet>();
    }
}
