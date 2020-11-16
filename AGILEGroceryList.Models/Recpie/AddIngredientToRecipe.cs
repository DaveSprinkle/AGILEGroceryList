using AGILEGroceryList.Data.Measurements;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGILEGroceryList.Models
{
    public class AddIngredientToRecipe
    {
        [Required]
        public int RecipeId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        public string Ingredient { get; set; }
        public TypeOfMeasurement TypeOfMeasurement { get; set; }
        public int Quanity { get; set; }
    }
}
