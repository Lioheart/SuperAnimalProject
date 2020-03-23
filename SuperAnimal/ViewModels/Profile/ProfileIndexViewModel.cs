using SuperAnimal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAnimal.ViewModels.Profile
{
    public class ProfileIndexViewModel
    {
        public string UserId { get; set; }

        public IEnumerable<Models.Pet> Pets { get; set; }
    }
}
