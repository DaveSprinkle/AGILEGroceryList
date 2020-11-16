using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGILEGroceryList.Data.Measurements
{
    public class Measurements
    {
        [Key]
        public int MeasurementsId { get; set; }
        public string Name { get; set; }//Cups or grams
        public TypeOfMeasurement TypeOfMeasurement { get; set; }//Volume / Mass / Quanity
        public string Conversion { get; set; }// from basic number to this value
    }
    public enum TypeOfMeasurement
    {
        Volume,
        Mass,
        Quantity
    }
}
