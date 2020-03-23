using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperAnimal.Services;
using SuperAnimal.ViewModels.Pet;

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
        public IActionResult AddPet(string userId) => View(new AddPetViewModel { UserId = userId });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPet(AddPetViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = PetService.CreateNewPet(model);
                return RedirectToAction(nameof(PetController.Index), "Pet", new { id = result.Data.Id });
            }
            return View(model);
        }



    }
}