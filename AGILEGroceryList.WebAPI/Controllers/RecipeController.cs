using AGILEGroceryList.Models;
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
    public class RecipeController : ApiController
    {
        //initiate private service
        private RecipeServices CreateRecipeService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            RecipeServices recipeService = new RecipeServices(userId);
            return recipeService;
        }

        //CRUD

        //=====Create======//
        //Post
        [HttpPost]
        public async Task<IHttpActionResult> CreateRecipe(CreateRecipe model)
        {
            //check if model is valid
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //instantiate the service
            RecipeServices service = CreateRecipeService();

            if (await service.CreateRecipe(model) == false)
            {
                return InternalServerError();
            }

            return Ok();
        }

        //=======READ=====//
        //Get All
        [HttpGet]
        public async Task<IHttpActionResult> GetAllRecipes()
        {
            //instantiate a service
            RecipeServices service = CreateRecipeService();

            //return the values as an ienumerable
            IEnumerable<RecipeListItem> recipes = await service.GetRecipes();

            return Ok(recipes);
        }

        //======Update=======//
        [HttpPut]
        public async Task<IHttpActionResult> AddRecipeIngredient([FromUri] int id, [FromBody] AddIngredientToRecipe model)
        {
            RecipeServices service = CreateRecipeService();

            if(await service.AddIngredientToRecipeById(id, model) == false)
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
