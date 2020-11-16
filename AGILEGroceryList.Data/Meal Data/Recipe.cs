using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGILEGroceryList.Data
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Instructions { get; set; }

        public List<Ingredient> Ingredients { get; set; }


    }
}
