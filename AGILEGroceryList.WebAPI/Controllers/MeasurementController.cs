using AGILEGroceryList.Models;
using AGILEGroceryList.Models.GroceryList;
using AGILEGroceryList.Models.Measurement;
using AGILEGroceryList.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AGILEGroceryList.WebAPI.Controllers
{
    public class MeasurementController : ApiController
    {
        //CRUD
        private MeasurementService CreateMeasurementService()
        {
            MeasurementService measurementService = new MeasurementService();
            return measurementService;
        }

        //=====Create======//
        //Post
        [HttpPost]
        public async Task<IHttpActionResult> CreateMeasurement(CreateMeasurement model)
        {
            //check if model is valid
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MeasurementService service = CreateMeasurementService();

            if (await service.CreateMeasurement(model) == false)
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
