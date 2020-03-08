using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using SuperAnimal.Data;
using SuperAnimal.Models;
using SuperAnimal.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAnimal.Services
{
    public class AccountService
    {
        private readonly ApplicationDbContext Context;
        private readonly UserManager<AppUser> UserManager;
        private readonly SignInManager<AppUser> SignInManager;
        private readonly ILogger Logger;
        private readonly EmailService EmailService;

        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            ILogger<AccountService> logger, ApplicationDbContext context, EmailService emailService)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Logger = logger;
            Context = context;
            EmailService = emailService;
        }

        public async Task<IdentityResult> RegisterNewUser(RegisterViewModel model)
        {

            var user = new AppUser { UserName = model.Email, Email = model.Email };
            var result = await UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                Logger.LogInformation("User created a new account");

                EmailService.SendWelcomeMail(user);

                await SignInManager.SignInAsync(user, isPersistent: false);
                Logger.LogInformation("User is login in");

            }
            return result;
        }

        public async Task<SignInResult> Login(LoginViewModel model)
        {
            return await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
        }

        public async void Logout()
        {
            await SignInManager.SignOutAsync();
            Logger.LogInformation("User logged out.");
        }


    }
}

