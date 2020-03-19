using Microsoft.AspNetCore.Identity;
using SuperAnimal.Data;
using SuperAnimal.Models;
using SuperAnimal.Services.ServiceResponses;
using SuperAnimal.ViewModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SuperAnimal.Services
{
    public class ProfileService
    {
        private readonly ApplicationDbContext Context;
        private readonly UserManager<AppUser> UserManager;

        public ProfileService(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            Context = context;
            UserManager = userManager;
        }

        public ServiceResponse<ProfileIndexViewModel> GetProfileIndexViewModel(ClaimsPrincipal claimsPrincipal)
        {
            var userIdString = UserManager.GetUserId(claimsPrincipal);

            try
            {
                var pets = Context.Pets.Where(x => x.UserId == userIdString).ToList();

                var model = new ProfileIndexViewModel
                {
                    UserId = userIdString,
                    Pets = pets
                };

                return ServiceResponse<ProfileIndexViewModel>.Ok(model);
            }
            catch (FormatException)
            {
                return ServiceResponse<ProfileIndexViewModel>.Error();
            }
            catch (OverflowException)
            {
                return ServiceResponse<ProfileIndexViewModel>.Error();
            }


        }
    }
}
