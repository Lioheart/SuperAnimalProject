using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SuperAnimal.Data;
using SuperAnimal.Models;
using SuperAnimal.Services.ServiceResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAnimal.Services
{
    public class DealService : BaseService
    {
        private readonly EmailService _emailService;

        public DealService(ILogger<DealService> logger, ApplicationDbContext context, EmailService emailService) 
            : base(logger, context)
        {
            _emailService = emailService;
        }


        public ServiceResponse<bool> SendEmailDeal(AppUser user, int petId)
        {
            var pet = Context.Pets.Include(x => x.User).FirstOrDefault(x => x.Id == petId);
            var ownerEmail = pet.User.Email;

            var result = _emailService.SendDealEmail(user.Email, user.UserName, pet.User.Email, 
                pet.User.UserName, pet.Name);

            if(result.Success)
                return ServiceResponse<bool>.Ok();

            return ServiceResponse<bool>.Error();
        }
    }
}
