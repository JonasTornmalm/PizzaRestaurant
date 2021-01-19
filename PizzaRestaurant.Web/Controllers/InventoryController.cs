using Microsoft.AspNetCore.Mvc;
using PizzaRestaurant.Web.DTOs;
using PizzaRestaurant.Web.Models;
using PizzaRestaurant.Web.RESTClients;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaRestaurant.Web.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryServiceAPI _inventoryServiceAPI;
        public InventoryController(IInventoryServiceAPI inventoryServiceAPI)
        {
            _inventoryServiceAPI = inventoryServiceAPI;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _inventoryServiceAPI.GetInventory();

            var deserialize = new NewtonsoftJsonContentSerializer();
            var model = await deserialize.DeserializeAsync<List<Ingredient>>(response);

            if (model == null)
            {
                ModelState.AddModelError("", "No ingredients found");
                return View(new List<Ingredient>());
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MassDelivery()
        {
            var response = await _inventoryServiceAPI.MassDelivery();

            if (!response.IsSuccessStatusCode)
            {
                TempData["ResponseMessage"] = "Was not able to order a mass delivery of ingredients";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromForm] Ingredient model)
        {
            if (id == 0 || model.Amount < 0)
            {
                TempData["ResponseMessage"] = "Invalid input";
                return RedirectToAction("Index");
            }

            var editInventoryDTO = new EditInventoryDTO()
            {
                Id = id,
                Amount = model.Amount
            };

            var response = await _inventoryServiceAPI.EditInventory(editInventoryDTO);

            if (!response.IsSuccessStatusCode)
            {
                TempData["ResponseMessage"] = "Could not update inventory";
                return RedirectToAction("Index");
            }

            TempData["ResponseMessage"] = "Inventory was updated";
            return RedirectToAction("Index");
        }
    }
}
