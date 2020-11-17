using AGILEGroceryList.Models;
using AGILEGroceryList.Models.GroceryList;
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
    public class GroceryController : ApiController
    {
        //initiate private service
        private GroceryService CreateGroceryService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            GroceryService groceryService = new GroceryService(userId);
            return groceryService;
        }

        //CRUD

        //=====Create======//
        //Post
        [HttpPost]
        public async Task<IHttpActionResult> CreateGroceryList(GroceryCreate grocery)
        {
            //check if model is valid
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //instantiate the service
            GroceryService service = CreateGroceryService();

            if (await service.CreateGroceryList(grocery) == false)
            {
                return InternalServerError();
            }

            return Ok();
        }

        //=======READ=====//
        //Get All
        [HttpGet]
        public async Task<IHttpActionResult> GetAllGroceryLists()
        {
            //instantiate a service
            GroceryService service = CreateGroceryService();

            //return the values as an ienumerable
            IEnumerable<GroceryListItem> groceries = await service.GetGroceryLists();

            return Ok(groceries);
        }

        //Get by Id
        [HttpGet]
        public async Task<IHttpActionResult> GetGroceryListById([FromUri] int id)
        {
            GroceryService service = CreateGroceryService();

            IEnumerable < GroceryListItem > groceryList = await service.GetGroceryListById(id);

            return Ok(groceryList);
        }


        //======Update=======//
        [HttpPut]
        public async Task<IHttpActionResult> UpdateGroceryList([FromUri] int id, [FromBody] GroceryEdit model)
        {
            GroceryService service = CreateGroceryService();

            if(await service.UpdateGroceryListById(id, model) == false)
            {
                return InternalServerError();
            }

            return Ok();
        }



        //=======Delete=======//
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteGroceryList(int id)
        {
            GroceryService service = CreateGroceryService();

            if(await service.DeleteGroceryListById(id) == false)
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
