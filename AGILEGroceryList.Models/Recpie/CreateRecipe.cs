using AGILEGroceryList.Data.Measurements;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGILEGroceryList.Models
{
    public class CreateRecipe
    {
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Instructions { get; set; }
        [Required]
        public string Ingredient { get; set; }
        [Required]
        public TypeOfMeasurement TypeOfMeasurement { get; set; }
        [Required]
        public int Quanity { get; set; }
    }
}
