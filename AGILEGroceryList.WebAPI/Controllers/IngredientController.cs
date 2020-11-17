using AGILEGroceryList.Data;
using AGILEGroceryList.Models;
using AGILEGroceryList.Models.Ingredient;
using AGILEGroceryList.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AGILEGroceryList.WebAPI.Controllers
{
    public class IngredientController : ApiController
    {

        private readonly ApplicationDbContext _context = new ApplicationDbContext();


        private IngredientServices CreateIngredientService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            IngredientServices ingredientService = new IngredientServices(userId);
            return ingredientService;
        }



        //Create
        [HttpPost]
        public async Task<IHttpActionResult> Create(Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                _context.Ingredients.Add(ingredient);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest(ModelState);
        }


        [HttpGet]

        public async Task<IHttpActionResult> GetAll()
        {
            List<Ingredient> ingredients = await _context.Ingredients.ToListAsync();

            return Ok(ingredients);
        }




        [HttpPut]
        public async Task<IHttpActionResult> UpdateProduct([FromUri] int id, [FromBody] Ingredient model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Ingredient ingredient = await _context.Ingredients.FindAsync(id);

            if (ingredient == null)
            {
                return NotFound();

            }

            ingredient.Name = model.Name;
            
            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok();
            }

            return InternalServerError();
        }



        //Delete

        [HttpDelete]

        public async Task<IHttpActionResult> DeleteProduct(int id)
        {

            Ingredient ingredient = await _context.Ingredients.FindAsync(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            _context.Ingredients.Remove(ingredient);

            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok();
            }

            return InternalServerError();
        }

    }
}
