using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaRestaurant.Web.DTOs
{
    public class AddToCartDTO
    {
        public int PizzaMenuNumber { get; set; }
        public int SodaMenuNumber { get; set; }
    }
}
