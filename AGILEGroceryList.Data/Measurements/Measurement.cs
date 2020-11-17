using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGILEGroceryList.Data.Measurements
{
    public class Measurement
    {
        [Key]
        public int MeasurementId { get; set; }
        public string Name { get; set; }//Cups or grams
        public TypeOfMeasurement TypeOfMeasurement { get; set; }//Volume / Mass / Quanity
        public string Conversion { get; set; }// from basic number to this value x*Conversion = Basic Storage Value | BasicStorageValue* Conversion = Valuse for grocery list
    }
    public enum TypeOfMeasurement
    {
        Volume=1,
        Mass,
        Quantity
    }
}
