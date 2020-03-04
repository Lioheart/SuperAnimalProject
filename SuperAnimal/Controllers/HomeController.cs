using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SuperAnimal.Data;
using SuperAnimal.Models;

namespace SuperAnimal.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext Context { get; }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            Context = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Test()
        {
            //var pets = Context.Pets.ToList();

            //Context.Add(new Pet
            //{
            //    Name = "dzieckodupy",
            //    BirthDate = new DateTime(2012, 2, 21),
            //    DeathDate = new DateTime(2012, 2, 22),
            //    Father = Context.Pets.Where(x => x.PetId == 2).FirstOrDefault()
            //});
            //Context.SaveChanges();

           // var xd = Context.AppUsers.Where(x => x.Id > 0).Include(x => x.Pets).ToList();

            //return View(new ErrorViewModel());
        }
    }
}
