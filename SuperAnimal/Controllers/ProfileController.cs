using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperAnimal.ViewModels.Profile;
using Microsoft.AspNetCore.Identity;
using SuperAnimal.Services;
using SuperAnimal.Models;
using SuperAnimal.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace SuperAnimal.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
    {
        readonly ProfileService _profileService;

        public ProfileController(ProfileService profileService, UserManager<AppUser> userManager, IUserRepository userRepository)
            : base(userManager, userRepository)
        {
            _profileService = profileService;
        }

        public IActionResult Index()
        {
            var result = _profileService.GetProfileIndexViewModel(GetLoggedUser());
            
            return View(result.Data);
        }
    }
}