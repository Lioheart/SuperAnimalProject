using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SuperAnimal.Models;
using SuperAnimal.Repositories.Interfaces;
using SuperAnimal.Services;
using SuperAnimal.ViewModels.Deal;

namespace SuperAnimal.Controllers
{
    public class DealController : BaseController
    {
        readonly IPetRepository _petRepository;
        private readonly DealService _dealService;

        public DealController(UserManager<AppUser> userManager, IUserRepository userRepository, 
            IPetRepository petRepository, DealService dealService) : base(userManager, userRepository)
        {
            _petRepository = petRepository;
            _dealService = dealService;
        }

        public IActionResult Index(string searchedPetName)
        {
            var pets = _petRepository.GetPetsForDeal(searchedPetName);

            var viewModel = new DealIndexViewModel()
            {
                Pets = pets,
                SearchedPetName = searchedPetName
            };

            return View(viewModel);
        }

        public IActionResult Deal(int petId)
        {
            var result = _dealService.SendEmailDeal(GetLoggedUser);

            if (result.Success)
                return RedirectToAction(nameof(HomeController.Index), "Home");
            else
                return ErrorPage();

        }
    }
}