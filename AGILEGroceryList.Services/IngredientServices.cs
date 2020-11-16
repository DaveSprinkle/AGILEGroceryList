using AGILEGroceryList.Data;
using AGILEGroceryList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGILEGroceryList.Services
{
    public class IngredientServices
    {


		private readonly Guid _userId;

		public IngredientServices(Guid userId)
		{
			_userId = userId;
		}




		public bool IngredientCreate(CreateIngredient model)
		{
			var entity =
				new Ingredient
				{
					Name = model.Name,
				};

			using (var ctx = new ApplicationDbContext())
			{
				ctx.Ingredients.Add(entity);
				return ctx.SaveChanges() == 1;
			}
		}

    }
}
