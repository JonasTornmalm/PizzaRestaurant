using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaRestaurant.Api.Inventory.DTOs
{
    public class EditInventoryDTO
    {
        public int Id { get; set; }
        public int Amount { get; set; }
    }
}
