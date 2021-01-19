using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaRestaurant.Api.Inventory.DTOs
{
    public class OrderDTO
    {
        public List<Pizza> Pizzas { get; set; }
        public List<Soda> Sodas { get; set; }
        public double TotalPrice { get; set; }
        public bool IsEmpty { get; set; }
    }
    public class Pizza
    {
        public List<Ingredient> PizzaIngredients { get;set;}
        public List<Ingredient> ExtraIngredients { get;set;}
        public Guid Id { get; set; }
        public int MenuNumber { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
    public class Soda
    {
        public Guid Id { get; set; }
        public int MenuNumber { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
    public class Ingredient
    {
        public Guid Id { get; set; }
        public int MenuNumber { get; set; }
        private string IngredientName;
        public string Name { get; set; }
        public IngredientEnum IngredientOption { get; set; }
        public double Price { get; set; }
    }
    public enum IngredientEnum
    {
        Ham = 1,
        Pineapple = 2,
        Mushrooms = 3,
        Onion = 4,
        KebabSauce = 5,
        Shrimps = 6,
        Clams = 7,
        Artichoke = 8,
        Kebab = 9,
        Coriander = 10,

        //Free
        Pepperoni = 11,
        Salad = 12,
        Tomato = 13,
        Cheese = 14,
        Tomatosauce = 15
    }
}
