using AGILEGroceryList.Data;
using AGILEGroceryList.Data.Measurements;
using AGILEGroceryList.Models;
using AGILEGroceryList.Models.Ingredient;
using AGILEGroceryList.Models.Measurement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AGILEGroceryList.Services
{
    public class MeasurementService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();


        //==========================CREATE===============================//

        public async Task<bool> CreateMeasurementList(CreateMeasurement model)
        {
            var entity =
                new Measurement()
                {
                    Name = model.Name,
                    TypeOfMeasurement = (TypeOfMeasurement) Enum.Parse(typeof(TypeOfMeasurement), model.TypeOfMeasurementString),
                    Conversion = model.Conversion
                };

            _context.Measurements.Add(entity);
            return await _context.SaveChangesAsync() == 1;
        }

    }
}
