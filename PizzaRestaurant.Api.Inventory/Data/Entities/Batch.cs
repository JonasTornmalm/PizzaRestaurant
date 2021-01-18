using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaRestaurant.Api.Inventory.Data.Entities
{
    public abstract class Batch
    {
        public Batch()
        {
            Created = Modified = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }
        public Guid Id { get; set; }
        public long Created { get; set; }
        public long Modified { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
