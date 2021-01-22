using Microsoft.AspNetCore.Mvc;
using PizzaRestaurant.Web.Models;
using PizzaRestaurant.Web.RESTClients.Interfaces;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaRestaurant.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IPizzaServiceAPI _pizzaServiceAPI;
        public OrderController(IPizzaServiceAPI pizzaServiceAPI)
        {
            _pizzaServiceAPI = pizzaServiceAPI;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _pizzaServiceAPI.GetPendingOrders();

            var deserialize = new NewtonsoftJsonContentSerializer();
            var model = await deserialize.DeserializeAsync<List<Order>>(response);

            if (model == null)
            {
                ModelState.AddModelError("", "No pending order atm");
                return View(new List<Order>());
            }

            var sortedModel = model.OrderByDescending(x => x.modified);

            return View(sortedModel);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder()
        {
            var response = await _pizzaServiceAPI.PlaceOrder();

            if (!response.IsSuccessStatusCode)
            {
                TempData["ResponseMessage"] = $"Was not able to place order";
                return RedirectToAction("Index", "Cart");
            }

            TempData["ResponseMessage"] = $"Your order was placed";

            return RedirectToAction("Index");
        }
    }
}
