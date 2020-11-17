using AGILEGroceryList.Data;
using AGILEGroceryList.Models;
using AGILEGroceryList.Models.Ingredient;
using AGILEGroceryList.Models.Ingredient;
using System;
using System.Collections.Generic;
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


        public IEnumerable<ListIngredient> GetIngredients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ingredients
                        .Select(
                            e =>
                                new ListIngredient
                                {
                                    IngredientId = e.IngredientId,
                                    Name = e.Name
                                }
                        );

                return query.ToArray();
            }
        }

        
        
        
        
        //==========================GET INGREDIENT BY NAME===============================//


        public IEnumerable<ListIngredient> GetIngredientByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ingredients
                        .Where(e => e.Name == name)
                        .Select(
                            e =>
                                new ListIngredient
                                {
                                    IngredientId = e.IngredientId,
                                    Name = e.Name,
                                }
                        );
                return query.ToArray();
            }
        }


        //==========================GET INGREDIENT BY NAME===============================//
















    }
}
