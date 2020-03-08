using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SuperAnimal.Controllers
{
    public class PetController : Controller
    {
        public IActionResult Index(int id)
        {
            return View();
        }

        // GET: /Pet/AddPet
        [HttpGet]
        public IActionResult AddPet() => View();
        
    }
}