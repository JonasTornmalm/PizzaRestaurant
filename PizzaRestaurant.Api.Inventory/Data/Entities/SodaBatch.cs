using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaRestaurant.Api.Inventory.Data.Entities
{
    public class SodaBatch : Batch
    {
        public int CocaCola { get; set; }
        public int Fanta { get; set; }
        public int Sprite { get; set; }
    }
}
