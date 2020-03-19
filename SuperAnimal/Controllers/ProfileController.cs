using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperAnimal.ViewModels.Profile;
using Microsoft.AspNetCore.Identity;
using SuperAnimal.Services;

namespace SuperAnimal.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ProfileService ProfileService;

        public ProfileController(ProfileService profileService)
        {
            ProfileService = profileService;
        }

        public IActionResult Index()
        {
            var result = ProfileService.GetProfileIndexViewModel(HttpContext.User);

            return View(result.Data);
        }
    }
}