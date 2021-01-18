using Microsoft.EntityFrameworkCore;
using PizzaRestaurant.Api.Inventory.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaRestaurant.Api.Inventory.Data
{
    public class InventoryDbContext : DbContext
    {
        public DbSet<IngredientBatch> IngredientBatches { get; set; }
        public DbSet<SodaBatch> SodaBatches { get; set; }
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IngredientBatch>()
                .HasData(new IngredientBatch()
                {
                    Ham = 10,
                    Pineapple = 10,
                    Mushrooms = 10,
                    Onion = 10,
                    KebabSauce = 10,
                    Shrimps = 10,
                    Clams = 10,
                    Artichoke = 10,
                    Kebab = 10,
                    Coriander = 10,
                    Pepperoni = 10,
                    Salad = 10,
                    Tomato = 10,
                    Cheese = 10,
                    Tomatosauce = 10
                });

            builder.Entity<SodaBatch>()
                .HasData(new SodaBatch()
                {
                    CocaCola = 10,
                    Fanta = 10,
                    Sprite = 10
                });
        }
    }
}
