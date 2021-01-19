using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaRestaurant.Web.DTOs
{
    public class UpdateCartDTO
    {
        public Guid PizzaId { get; set; }
        public List<ExtraIngredientDTO> ExtraIngredients { get; set; }
    }
    public class ExtraIngredientDTO
    {
        public int MenuNumber { get; set; }
    }
}
