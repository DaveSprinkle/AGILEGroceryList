﻿using AGILEGroceryList.Data.Measurements;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGILEGroceryList.Models
{
    public class CreateRecipe
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Instructions { get; set; }

        [Required]
        public string MeasurementName { get; set; }

        [Required]
        public string IngredientName { get; set; }

        [Required]
        public int Quanity { get; set; }
    }
}
