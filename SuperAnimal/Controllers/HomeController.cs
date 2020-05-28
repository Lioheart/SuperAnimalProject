using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using SuperAnimal.Data;
using SuperAnimal.Models;
using SuperAnimal.ViewModels.Home;

namespace SuperAnimal.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
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


        public IActionResult Covid()
        {
            var client = new RestClient("https://covid-19-data.p.rapidapi.com/totals?format=json");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "covid-19-data.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "fe7e68095dmsh3ab1bccf87f3dcdp1d3d30jsne245d22c32b8");
            IRestResponse response = client.Execute(request);

            var result =  JsonConvert.DeserializeObject<List<CovidViewModel>>(response.Content);

            return View(result.First());
        }

        public IActionResult CovidJSON()
        {
            var client = new RestClient("https://covid-19-data.p.rapidapi.com/totals?format=json");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "covid-19-data.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "fe7e68095dmsh3ab1bccf87f3dcdp1d3d30jsne245d22c32b8");
            IRestResponse response = client.Execute(request);

            //var json = JsonConvert.DeserializeObject(response.Content);

            //var xd = json.

            return Ok(response.Content);

            

        }
    }
}
