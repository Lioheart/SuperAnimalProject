using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SuperAnimal.Models;
using SuperAnimal.Repositories.Interfaces;
using SuperAnimal.Services;

namespace SuperAnimal.Controllers
{
    public class DealChatController : BaseController
    {
        private readonly DealChatService _dealChatService;

        public DealChatController(UserManager<AppUser> userManager, IUserRepository userRepository, DealChatService dealChatService)
            : base(userManager, userRepository)
        {
            _dealChatService = dealChatService;
        }

        public async Task<IActionResult> Index(int petId, string connectionId)
        {
            var result = await _dealChatService.JoinChat(GetLoggedUser(), petId, connectionId);

            if (result.Success)
                return View(result.Data);
            else
                return ErrorPage();

        }
    }
}