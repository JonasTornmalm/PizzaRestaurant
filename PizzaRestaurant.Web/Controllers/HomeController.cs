using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PizzaRestaurant.Web.Models;
using PizzaRestaurant.Web.RESTClients.Interfaces;
using Refit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaRestaurant.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPizzaServiceAPI _pizzaServiceAPI;

        public HomeController(ILogger<HomeController> logger, IPizzaServiceAPI pizzaServiceAPI)
        {
            _logger = logger;
            _pizzaServiceAPI = pizzaServiceAPI;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Menu()
        {
            var response = await _pizzaServiceAPI.GetMenu();

            var deserialize = new NewtonsoftJsonContentSerializer();
            var model = await deserialize.DeserializeAsync<Menu>(response);

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
