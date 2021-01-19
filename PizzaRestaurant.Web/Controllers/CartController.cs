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

            if (model.isEmpty)
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
                TempData["ResponseMessage"] = "Was not able to add to cart";
                return RedirectToAction("Index");
            }

            TempData["ResponseMessage"] = $"Added {category} to cart";
            return RedirectToAction("Menu", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> ClearCart()
        {
            var response = await _pizzaServiceAPI.ClearCart();

            if (!response.IsSuccessStatusCode)
            {
                TempData["ResponseMessage"] = "Cart already empty";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddExtraIngredients(Guid pizzaId)
        {
            var model = new AddExtraIngredientsModel()
            {
                PizzaId = pizzaId,
                ExtraIngredients = new List<ExtraIngredient>()
                {
                    new ExtraIngredient(){menuNumber = 1, name = "Ham"},
                    new ExtraIngredient(){menuNumber = 2, name = "Pineapple"},
                    new ExtraIngredient(){menuNumber = 3, name = "Mushrooms"},
                    new ExtraIngredient(){menuNumber = 4, name = "Onion"},
                    new ExtraIngredient(){menuNumber = 5, name = "KebabSauce"},
                    new ExtraIngredient(){menuNumber = 6, name = "Shrimps"},
                    new ExtraIngredient(){menuNumber = 7, name = "Clams"},
                    new ExtraIngredient(){menuNumber = 8, name = "Artichoke"},
                    new ExtraIngredient(){menuNumber = 9, name = "Kebab"},
                    new ExtraIngredient(){menuNumber = 10, name = "Coriander"}
                }
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddExtraIngredients(Guid pizzaId, [FromForm] AddExtraIngredientsModel model)
        {
            if (ModelState.IsValid)
            {
                var extraIngredients = new List<ExtraIngredientDTO>()
                {
                    new ExtraIngredientDTO(){ MenuNumber = model.MenuNumber }
                };
                var updateCartDTO = new UpdateCartDTO()
                {
                    PizzaId = pizzaId,
                    ExtraIngredients = extraIngredients
                };
                var response = await _pizzaServiceAPI.AddExtraIngredients(updateCartDTO);

                if (!response.IsSuccessStatusCode)
                {
                    TempData["ResponseMessage"] = "Was not able to add extra ingredient";
                    return RedirectToAction("Index");
                }

                return RedirectToAction("AddExtraIngredients", new { pizzaId = pizzaId });
            }
            return BadRequest();
        }
    }
}
