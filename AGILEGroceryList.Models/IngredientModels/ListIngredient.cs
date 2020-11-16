using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGILEGroceryList.Models
{
    public class IngredientList
    {
        [Key]
        public string IngredientId { get; set; }

        public string Name { get; set; }

    }
}
