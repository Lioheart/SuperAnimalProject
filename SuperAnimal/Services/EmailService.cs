using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SuperAnimal.Data;
using SuperAnimal.Models;
using SuperAnimal.Services.ServiceResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SuperAnimal.Services
{
    public class EmailService : BaseService
    {
        private readonly SmtpClient Client;

        public IConfiguration Configuration { get; }

        public EmailService(IConfiguration configuration, ILogger<EmailService> logger, ApplicationDbContext context) : base(logger, context)
        {
            Configuration = configuration;

            Client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(SenderEmailAddress, EmailPassword),
                EnableSsl = true
            };
        }

        private string SenderEmailAddress
        {
            get => Configuration.GetSection("EmailCredential").GetSection("EmailAddress").Value;
        }

        private string EmailPassword
        {
            get => Configuration.GetSection("EmailCredential").GetSection("Password").Value;
        }

        public void SendWelcomeMail(AppUser user) =>
            Client.Send(SenderEmailAddress, SenderEmailAddress, GetWelcomeMessageTitle(user), GetWelComeMessageBody(user));


        private string GetWelcomeMessageTitle(AppUser user) =>
            string.Format("Hello {0}, welcome to SuperAnimalProject", user.UserName);

        private string GetWelComeMessageBody(AppUser user) =>
            string.Format("{0}, thank you for register in SuperAnimal", user.UserName);

        public ServiceResponse<bool> SendDealEmail(
            string userEmail, string userName, string ownerEmail, string ownerUserNane, string petName)
        {
            try
            {
                Client.Send(SenderEmailAddress, ownerEmail, GetDealEmailTitle(userName), 
                    GetDealEmailBody(userEmail, userName, ownerUserNane, petName));

                return ServiceResponse<bool>.Ok();
            }
            catch(Exception ex)
            {
                return ServiceResponse<bool>.Error(ex.Message);
            }
        }

        private string GetDealEmailTitle(string userName) =>
            string.Format("New deal for your animal from {0}", userName);

        private string GetDealEmailBody(string userEmail, string userName, string ownerUserNane, string petName) =>
            string.Format("Hello {0}, you have new deal from {1}. {1} wants to order breeding with {2}." +
                " You can write to {3} and make deal.", ownerUserNane, userName, petName, userEmail);

    }
}
