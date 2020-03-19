using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperAnimal.Services;

namespace SuperAnimal.Controllers
{
    public class PetController : Controller
    {
        private readonly PetService PetService;

        public PetController(PetService petService)
        {
            PetService = petService;
        }

        public IActionResult Index(int id)
        {
            return View();
        }

        // GET: /Pet/AddPet
        [HttpGet]
        public IActionResult AddPet() => View();
        
    }
}