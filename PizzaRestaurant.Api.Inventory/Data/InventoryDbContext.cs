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
        public DbSet<Ingredient> Inventory { get; set; }
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Ingredient>().HasData(new Ingredient { Id = 1, Name = "Ham", Amount = 10 });
            builder.Entity<Ingredient>().HasData(new Ingredient { Id = 2, Name = "Pineapple", Amount = 10 });
            builder.Entity<Ingredient>().HasData(new Ingredient { Id = 3, Name = "Mushrooms", Amount = 10 });
            builder.Entity<Ingredient>().HasData(new Ingredient { Id = 4, Name = "Onion", Amount = 10 });
            builder.Entity<Ingredient>().HasData(new Ingredient { Id = 5, Name = "KebabSauce", Amount = 10 });
            builder.Entity<Ingredient>().HasData(new Ingredient { Id = 6, Name = "Shrimps", Amount = 10 });
            builder.Entity<Ingredient>().HasData(new Ingredient { Id = 7, Name = "Clams", Amount = 10 });
            builder.Entity<Ingredient>().HasData(new Ingredient { Id = 8, Name = "Artichoke", Amount = 10 });
            builder.Entity<Ingredient>().HasData(new Ingredient { Id = 9, Name = "Kebab", Amount = 10 });
            builder.Entity<Ingredient>().HasData(new Ingredient { Id = 10, Name = "Coriander", Amount = 10 });
            builder.Entity<Ingredient>().HasData(new Ingredient { Id = 11, Name = "Pepperoni", Amount = 10 });
            builder.Entity<Ingredient>().HasData(new Ingredient { Id = 12, Name = "Salad", Amount = 10 });
            builder.Entity<Ingredient>().HasData(new Ingredient { Id = 13, Name = "Tomato", Amount = 10 });
            builder.Entity<Ingredient>().HasData(new Ingredient { Id = 14, Name = "Cheese", Amount = 10 });
            builder.Entity<Ingredient>().HasData(new Ingredient { Id = 15, Name = "Tomatosauce", Amount = 10 });
        }
    }
}
