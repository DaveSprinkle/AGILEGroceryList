using AGILEGroceryList.Data.Measurements;
using AGILEGroceryList.Models.Recpie;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGILEGroceryList.Models
{
    public class RecipeListItem
    {
        public int RecipeId { get; set; }
        
        public Guid OwnerId { get; set; }

        public string Name { get; set; }

        public string Instructions { get; set; }

        public List<IngredientInRecipe> IngredientsPrintout { get; set; }
    }
}
