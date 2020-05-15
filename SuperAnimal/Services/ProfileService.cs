using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
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
    public class ProfileService : BaseService
    {
        private readonly UserManager<AppUser> UserManager;

        public ProfileService(ApplicationDbContext context, UserManager<AppUser> userManager, ILogger<ProfileService> logger)
            : base(logger, context)
        {
            UserManager = userManager;
        }


        protected ServiceResponse<T> HandleException<T>(Func<ServiceResponse<T>> method)
        {
            try
            {
                return method.Invoke();
            }
            catch (FormatException)
            {
                return ServiceResponse<T>.Error();
            }
            catch (OverflowException)
            {
                return ServiceResponse<T>.Error();
            }
        }

        public ServiceResponse<ProfileIndexViewModel> GetProfileIndexViewModel(AppUser loggedUser)
        {
            ServiceResponse<ProfileIndexViewModel> method()
            {
                var pets = Context.Pets.Where(x => x.UserId == loggedUser.Id).ToList();

                var model = new ProfileIndexViewModel
                {
                    Pets = pets
                };

                return ServiceResponse<ProfileIndexViewModel>.Ok(model);
            }

            return HandleException(method);
        }
    }
}
