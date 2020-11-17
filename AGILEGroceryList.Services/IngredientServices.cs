using AGILEGroceryList.Data;
using AGILEGroceryList.Models;
using AGILEGroceryList.Models.Ingredient;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AGILEGroceryList.Services
{
    public class IngredientServices
    {


		private readonly Guid _userId;

		public IngredientServices(Guid userId)
		{
			_userId = userId;
		}


        //create a private context
        private readonly ApplicationDbContext _context = new ApplicationDbContext();


        //==========================CREATE===============================//


        public bool CreateNewIngredient(CreateIngredient ingredient)
        {
            if (ingredient is null)
            {
                return false;
            }

            var entity =
                new Ingredient()
                {
                    Name = ingredient.Name
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ingredients.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }




        //==========================GET ALL INGREDIENTS===============================//


        public async Task<List<ListIngredient>> GetIngredients()  //ListAllIngredients
        {
            var query =
                await
                _context
                .Ingredients
                .Select(
                    e =>
                    new ListIngredient()
                    {
                        Name = e.Name,
                        
                    }).ToListAsync();
            return query;
        }



       
        
        
        
        //==========================GET INGREDIENT BY NAME===============================//


        public async Task<List<ListIngredient>> GetIngredientByName([FromUri] string name)
        {
            var query =
                await
                _context
                .Ingredients
                .Where(e => e.Name == name)
                .Select(
                    e =>
                    new ListIngredient()
                    {
                        Name = e.Name,

                    }).ToListAsync();
            return query;
        }





        //==========================GET INGREDIENT BY NAME===============================//


        public bool EditIngredientByName([FromUri] int id, [FromBody] EditIngredient ingredient)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                .Ingredients
                .Single(e => e.IngredientId == id);
                entity.Name = ingredient.Name;
                return ctx.SaveChanges() == 1;

            }
        }



        //==========================DELETE INGREDIENT BY ID===============================//



        public bool DeletePostsById([FromUri] int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                .Ingredients
                .Single(e => e.IngredientId == id);
                ctx.Ingredients.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
