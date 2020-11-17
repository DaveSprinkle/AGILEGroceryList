using AGILEGroceryList.Data;
using AGILEGroceryList.Models.Ingredient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGILEGroceryList.Models
{
    public class GroceryListItem
    {
        public int GroceryListId { get; set; }

        public Guid OwnerId { get; set; }

        public string Name { get; set; }

        public List<ListIngredient> Ingredients { get; set; }
    }
}