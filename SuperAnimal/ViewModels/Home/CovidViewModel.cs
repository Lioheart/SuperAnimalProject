using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAnimal.ViewModels.Home
{
    public class CovidViewModel
    {
        public string Confirmed { get; set; }
        public string Recovered { get; set; }
        public string Critical { get; set; }
        public string Deaths { get; set; }
        public string LastChange { get; set; }
        public string LastUpdate { get; set; }
    }
}
