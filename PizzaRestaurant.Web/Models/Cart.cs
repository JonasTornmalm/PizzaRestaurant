using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaRestaurant.Web.Models
{
    public class Cart
    {
        public string orderId { get; set; }
        public List<Pizza> pizzas { get; set; }
        public List<Soda> sodas { get; set; }
        public int totalPrice { get; set; }
        public bool IsEmpty { get; set; }
    }
}
