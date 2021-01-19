using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaRestaurant.Web.Models
{
    public class Menu
    {
        public List<Pizza> pizzas { get; set; }
        public List<Soda> sodas { get; set; }
        public List<ExtraIngredient> extraIngredients { get; set; }
    }
    public class PizzaIngredient
    {
        public string name { get; set; }
    }

    public class Pizza
    {
        public Guid pizzaId { get; set; }
        public int menuNumber { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public List<PizzaIngredient> pizzaIngredients { get; set; }
        public List<ExtraIngredient> extraIngredients { get; set; }
    }

    public class Soda
    {
        public int menuNumber { get; set; }
        public string name { get; set; }
        public int price { get; set; }
    }

    public class ExtraIngredient
    {
        public int menuNumber { get; set; }
        public string name { get; set; }
        public int price { get; set; }
    }
}
