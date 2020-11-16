using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGILEGroceryList.Data
{
    public class GroceryList
    {
        [Key]
        public int GroceryListId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        public List<Ingredient> Ingredients { get; set; }
    }
}
