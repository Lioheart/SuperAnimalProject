using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SuperAnimal.Models;
using SuperAnimal.Repositories.Interfaces;
using SuperAnimal.Services;
using SuperAnimal.ViewModels.Pet;

namespace SuperAnimal.Controllers
{
    [Authorize]
    public class PetController : BaseController
    {
        private readonly PetService PetService;

        public PetController(PetService petService, UserManager<AppUser> userManager, IUserRepository userRepository)
            : base(userManager, userRepository)
        {
            PetService = petService;
        }

        public IActionResult Index(int petId)
        {
            var result = PetService.GetPetIndexViewModelForPetId(GetLoggedUser(), petId);
            if (!result.Success)
            {
                return ErrorPage();
            }
            return View(result.Data);
        }

        // GET: /Pet/AddPet
        [HttpGet]
        public IActionResult AddPet(string userId) => View(new AddPetViewModel { UserId = GetLoggedUser().Id });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPet(AddPetViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = PetService.CreateNewPet(model);
                return RedirectToAction(nameof(PetController.Index), "Pet", new { petId = result.Data.Id });
            }
            return View(model);
        }

        public IActionResult DeletePet(int petId)
        {
            var result = PetService.DeletePet(GetLoggedUser(), petId);
            if (result.Success)
                return RedirectToAction(nameof(ProfileController.Index), "Profile");
            else
                return ErrorPage();

        }


        [HttpGet]
        public IActionResult EditPet(int petId)
        {
            var result = PetService.GetEditPetViewModel(GetLoggedUser(), petId);
            if (result.Success)
                return View(result.Data);
            else
                return ErrorPage();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPet(EditPetViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = PetService.EditPet(GetLoggedUser(), model.Pet);

            if (result.Success)
                return RedirectToAction(nameof(PetController.Index), "Pet", new { petId = result.Data.Id });
            else
                return ErrorPage();

        }

    }
}