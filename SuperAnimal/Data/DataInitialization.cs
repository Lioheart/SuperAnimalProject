using Bogus;
using Microsoft.AspNetCore.Identity;
using SuperAnimal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace SuperAnimal.Data
{
    public class DataInitialization
    {
        private readonly ApplicationDbContext Context;
        private readonly UserManager<AppUser> UserManager;
        private const string PasswordForTestUsers = "Haslo12345!";

        public DataInitialization(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            Context = context;
            UserManager = userManager;
        }

        public void SeedUsers()
        {
            if (Context.Users.ToList().Count < 100)
            {
                var testUser = new AppUser
                {
                    Email = "email@email.wp.pl",
                    UserName = "TestUser"
                };

                testUser.PasswordHash = UserManager.PasswordHasher.HashPassword(testUser, PasswordForTestUsers);
                Context.Users.Add(testUser);
                //var result = await UserManager.CreateAsync(testUser, PasswordForTestUsers);
                Context.SaveChanges();

                var userFaker = new Faker<AppUser>()
                     .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                     .RuleFor(u => u.LastName, f => f.Name.LastName())
                     .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
                     .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName));

                var users = userFaker.Generate(100);

                foreach (var item in users)
                {
                    var task = UserManager.CreateAsync(item, PasswordForTestUsers);
                    task.Wait();
                }
            }
        }

        public void SeedPets()
        {
            var usersIds = Context.Users.Select(x => x.Id).ToList();

            if (Context.Pets.ToList().Count < 500)
            {
                var petFaker = new Faker<Pet>()
                    .RuleFor(p => p.Name, f => f.Name.FindName())
                    .RuleFor(p => p.UserId, f => f.PickRandom<string>(usersIds))
                    .RuleFor(p => p.Genre, f => f.PickRandom<Genre>().ToString())
                    .RuleFor(p => p.ProfilePhoto, f => f.Image.LoremFlickrUrl(300, 300, "Animal"))
                    .RuleFor(p => p.Description, f =>  f.Lorem.Text())
                    .RuleFor(p => p.BirthDate, f => f.Date.Past());

                var pets = petFaker.Generate(1000);

                Context.Pets.AddRange(pets);
                Context.SaveChanges();
            }
        }

        public enum Genre
        {
            Cat,
            Dog,
            Horse,
            Cow
        }

    }
}
