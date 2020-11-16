using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGILEGroceryList.Models
{
    public class ListIngredient
    {
        [Key]
        public string IngredientId { get; set; }

        public string Name { get; set; }

    }
}
