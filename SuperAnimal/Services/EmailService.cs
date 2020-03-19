using Microsoft.Extensions.Configuration;
using SuperAnimal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SuperAnimal.Services
{
    public class EmailService
    {
        private readonly SmtpClient Client;

        public IConfiguration Configuration { get; }

        private string SenderEmailAddress
        {
            get
            {
                return Configuration.GetSection("EmailCredential").GetSection("EmailAddress").Value;
            }
        }

        private string EmailPassword
        {
            get
            {
                return Configuration.GetSection("EmailCredential").GetSection("Password").Value;
            }
        }

        public EmailService(IConfiguration configuration)
        {
            Configuration = configuration;

            Client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(SenderEmailAddress, EmailPassword),
                EnableSsl = true
            };
        }

        public void SendWelcomeMail(AppUser user)
        {
            Client.Send(SenderEmailAddress, SenderEmailAddress, GetWelcomeMessageTitle(user), GetWelComeMessageBody(user));
        }

        public string GetWelcomeMessageTitle(AppUser user) =>
            string.Format("Hello {0}, welcome to SuperAnimalProject", user.UserName);
        
        public string GetWelComeMessageBody(AppUser user) =>
            string.Format("{0}, thank you for register in SuperAnimal", user.UserName);
   
    }
}
