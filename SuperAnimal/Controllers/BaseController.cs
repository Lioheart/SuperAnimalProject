using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SuperAnimal.Data;
using SuperAnimal.Models;
using SuperAnimal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAnimal.Controllers
{
    public class BaseController : Controller 
    {
        private readonly UserManager<AppUser> UserManager;

        private readonly IUserRepository UserRepository;

        public BaseController(UserManager<AppUser> userManager, IUserRepository userRepository)
        {
            UserManager = userManager;
            UserRepository = userRepository;
        }

        protected AppUser GetLoggedUser() =>
            UserRepository.GetUserById(UserManager.GetUserId(HttpContext.User));

        protected IActionResult ErrorPage()
        {
            return View("~/Views/Error.cshtml");
        }
    }

}
