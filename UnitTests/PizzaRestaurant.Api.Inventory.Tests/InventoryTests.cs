using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaRestaurant.Api.Inventory.Controllers;
using PizzaRestaurant.Api.Inventory.Data;
using PizzaRestaurant.Api.Inventory.Data.Entities;
using PizzaRestaurant.Api.Inventory.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace PizzaRestaurant.Api.Inventory.Tests
{
    [TestClass]
    public class InventoryTests
    {
        [TestMethod]
        public void GetInventoryTest()
        {
            var options = new DbContextOptionsBuilder<InventoryDbContext>()
            .UseInMemoryDatabase(databaseName: "InventoryDatabase")
            .Options;

            using (var context = new InventoryDbContext(options))
            {
                var controller = new InventoryController(context);

                var items = controller.GetInventory().Result;

                var okResult = items as OkObjectResult;

                Assert.IsNotNull(okResult);
                Assert.AreEqual(200, okResult.StatusCode);
            }
        }

        [TestMethod]
        public void MassDeliveryTest()
        {
            var options = new DbContextOptionsBuilder<InventoryDbContext>()
                .UseInMemoryDatabase(databaseName: "InventoryDatabase")
                .Options;

            using (var context = new InventoryDbContext(options))
            {
                var controller = new InventoryController(context);

                var inventory = context.Inventory.ToList();

                var massDelivery = controller.MassDelivery().Result;
                var okResult = massDelivery as OkResult;

                var totalIngredientAmount = 0;
                foreach (var ingredient in inventory)
                {
                    totalIngredientAmount += ingredient.Amount;
                }

                Assert.AreEqual(200, okResult.StatusCode);
                Assert.AreEqual(300, totalIngredientAmount);
            }
        }

        [TestMethod]
        public void EditInventoryTest()
        {
            var options = new DbContextOptionsBuilder<InventoryDbContext>()
                .UseInMemoryDatabase(databaseName: "InventoryDatabase")
                .Options;

            using (var context = new InventoryDbContext(options))
            {
                var controller = new InventoryController(context);

                var editInventoryDTO = new EditInventoryDTO()
                {
                    Id = 1,
                    Amount = 20
                };

                var toBeEdited = context.Inventory.Where(x => x.Id == editInventoryDTO.Id).FirstOrDefault();

                var expected = toBeEdited.Amount + 10;

                var result = controller.EditInventory(editInventoryDTO).Result;
                var okResult = result as OkResult;

                var actual = toBeEdited.Amount;

                Assert.AreEqual(200, okResult.StatusCode);
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
