using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaRestaurant.Api.Inventory.Data;
using PizzaRestaurant.Api.Inventory.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaRestaurant.Api.Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryDbContext _context;
        public InventoryController(InventoryDbContext context)
        {
            _context = context;
        }
        // GET: api/<InventoryController>
        [HttpGet]
        public async Task<IActionResult> GetInventory()
        {
            var inventory = await _context.Inventory.ToListAsync();
            return Ok(inventory);
        }

        // POST api/<InventoryController>
        [HttpPost]
        public async Task<IActionResult> ProcessOrder([FromBody] OrderDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var inventory = await _context.Inventory.ToListAsync();

            var pizzaList = request.Pizzas;

            var ingredientsOrdered = new List<Ingredient>();

            foreach (var pizza in pizzaList)
            {
                foreach (var ingredient in pizza.PizzaIngredients)
                {
                    ingredientsOrdered.Add(ingredient);
                }
                foreach (var extraIngredient in pizza.ExtraIngredients)
                {
                    ingredientsOrdered.Add(extraIngredient);
                }
            }

            foreach (var ingredient in ingredientsOrdered)
            {
                try
                {
                    var inventoryItem = inventory.Where(x => x.Name == ingredient.Name && x.InStock).FirstOrDefault();
                    inventoryItem.Amount = inventoryItem.Amount - 1;
                    _context.Inventory.Update(inventoryItem);
                }
                catch (NullReferenceException ex)
                {
                    return BadRequest(ex.Message);
                    throw;
                }
            }

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> MassDelivery()
        {
            var inventory = await _context.Inventory.ToListAsync();

            foreach (var ingredient in inventory)
            {
                ingredient.Amount = ingredient.Amount + 10;
                _context.Update(ingredient);
            }

            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT api/<InventoryController>/5
        [HttpPut]
        public async Task<IActionResult> EditInventory([FromBody] EditInventoryDTO request)
        {
            var inventoryItem = await _context.Inventory.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (inventoryItem == null)
                return BadRequest();

            inventoryItem.Amount = request.Amount;
            _context.Update(inventoryItem);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<InventoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
