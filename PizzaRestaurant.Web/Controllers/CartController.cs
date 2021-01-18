using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaRestaurant.Web.DTOs;
using PizzaRestaurant.Web.Models;
using PizzaRestaurant.Web.RESTClients.Interfaces;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PizzaRestaurant.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IPizzaServiceAPI _pizzaServiceAPI;
        public CartController(IPizzaServiceAPI pizzaServiceAPI)
        {
            _pizzaServiceAPI = pizzaServiceAPI;
        }
        // GET: CartController
        public async Task<IActionResult> Index()
        {
            var response = await _pizzaServiceAPI.GetCartContent();

            var deserialize = new NewtonsoftJsonContentSerializer();
            var model = await deserialize.DeserializeAsync<Cart>(response);

            if (model.IsEmpty)
            {
                ModelState.AddModelError("", "Your cart is empty");
                return View(model);
            }

            return View(model);
        }

        // POST: CartController/Create
        [HttpPost]
        public async Task<IActionResult> Add(string category, int menuNumber)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = new HttpResponseMessage();

            var addToCartDTO = new AddToCartDTO();

            switch (category)
            {
                case "pizza":
                    {
                        addToCartDTO.PizzaMenuNumber = menuNumber;
                        addToCartDTO.SodaMenuNumber = 0;
                        response = await _pizzaServiceAPI.AddToCart(addToCartDTO);
                    }
                    break;

                case "soda":
                    {
                        addToCartDTO.SodaMenuNumber = menuNumber;
                        addToCartDTO.PizzaMenuNumber = 0;
                        response = await _pizzaServiceAPI.AddToCart(addToCartDTO);
                    }
                    break;

                default:
                    break;
            }

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Bad request, cant add");
                return RedirectToAction("Menu", "Home");
            }

            return RedirectToAction("Index");
        }

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
