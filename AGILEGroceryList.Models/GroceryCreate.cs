using AGILEGroceryList.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGILEGroceryList.Models
{
    public class GroceryCreate
    {
        [Required]
        [MaxLength(40, ErrorMessage = "Grocery Name cannot be greater than 40 characters")]
        public string Name { get; set; }

        ////List of ingredients needed
        //public List<Ingredient> Ingredients { get; set; }

    }
}
