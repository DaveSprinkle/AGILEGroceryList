using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGILEGroceryList.Data
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }
        [Required]
        public string Name { get; set; }

        [ForeignKey(nameof(GroceryList))]
        public int GroceryListId { get; set; }
        public virtual GroceryList GroceryList { get; set; }
    }
}
