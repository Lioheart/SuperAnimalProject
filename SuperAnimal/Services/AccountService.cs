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

            var user = new AppUser { UserName = model.UserName, Email = model.Email };
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
            var user = Context.AspNetUsers.FirstOrDefault(x => x.UserName == model.Email || x.Email == model.Email);
            var checkResult = await SignInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (checkResult.Succeeded)
            {
                await SignInManager.SignInAsync(user, false);
                return checkResult;
            }

            return checkResult;
        }

        public async void Logout()
        {
            await SignInManager.SignOutAsync();
            Logger.LogInformation("User logged out.");
        }

        public void Seed()
        {
            var xd = new DataInitialization(Context,UserManager);
            xd.SeedUsers();
            xd.SeedPets();
        }


    }
}

