using AGILEGroceryList.Data.Measurements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGILEGroceryList.Models.Measurement
{
    public class CreateMeasurement
    {
        public string Name { get; set; }//Cups or grams
        public string TypeOfMeasurementString { get; set; }//Volume / Mass / Quanity
        public double Conversion { get; set; }// from basic number to this value x*Conversion = Basic Storage Value | BasicStorageValue* Conversion = Valuse for grocery list
    }
}
