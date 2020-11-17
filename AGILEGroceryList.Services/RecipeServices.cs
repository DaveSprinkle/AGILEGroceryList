using AGILEGroceryList.Data;
using AGILEGroceryList.Data.Measurements;
using AGILEGroceryList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AGILEGroceryList.Services
{
    public class RecipeServices
	{


		private readonly Guid _userId;

		public RecipeServices(Guid userId)
		{
			_userId = userId;
		}
        public bool CreateRecipe(CreateRecipe model)
        {
            var entity =
                new Recipe()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Instructions = model.Instructions,
                    Ingredients = new Dictionary<string, Dictionary<TypeOfMeasurement, int>>() { { model.Ingredient, new Dictionary<TypeOfMeasurement, int>() { { model.TypeOfMeasurement, model.Quanity } } } },
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Recipes.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
