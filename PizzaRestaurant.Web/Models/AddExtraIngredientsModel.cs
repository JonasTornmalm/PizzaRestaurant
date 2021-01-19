using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaRestaurant.Web.Models
{
    public class AddExtraIngredientsModel
    {
        public Guid PizzaId { get; set; }
        public List<ExtraIngredient> ExtraIngredients { get; set; }

        [Required]
        [Range(1, 10)]
        public int MenuNumber { get; set; }
    }
}
