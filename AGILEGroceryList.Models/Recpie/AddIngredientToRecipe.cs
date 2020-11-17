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
        public string MeasurementName { get; set; }

        [Required]
        public string IngredientName { get; set; }

        [Required]
        public int Quanity { get; set; }
    }
}
