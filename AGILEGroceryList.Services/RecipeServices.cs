using AGILEGroceryList.Data;
using AGILEGroceryList.Data.Measurements;
using AGILEGroceryList.Models;
using AGILEGroceryList.Models.Recpie;
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

        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        private readonly Guid _userId;

        public RecipeServices(Guid userId)
        {
            _userId = userId;
        }
        public async Task<bool> CreateRecipe(CreateRecipe model)//This needs vaification on the contoler to make sure the name of the measurement and ingredant esist
        {
            using (var ctx = new ApplicationDbContext())
            {
                int MeasurementId =
                    ctx
                        .Measurements
                        .Where(e => e.Name == model.MeasurementName)
                        .Select(
                            e => e.MeasurementId
                        ).FirstOrDefault();
                int IngredientId =
                    ctx
                        .Ingredients
                        .Where(e => e.Name == model.IngredientName)
                        .Select(
                            e => e.IngredientId
                        ).FirstOrDefault();
                var entity =
                    new Recipe()
                    {
                        OwnerId = _userId,
                        Name = model.Name,
                        Instructions = model.Instructions,
                        Ingredients = new Dictionary<int, List<int>>() { { 1, new List<int> { IngredientId, MeasurementId, model.Quanity } } },
                    };

                ctx.Recipes.Add(entity);

                return await ctx.SaveChangesAsync() == 1;
            }

        }
        public IEnumerable<RecipeListItem> GetRecipes()//get
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Recipes
                        .Select(
                            e =>
                                new RecipeListItem
                                {
                                    RecipeId = e.RecipeId,
                                    OwnerId = e.OwnerId,
                                    Name = e.Name,
                                    Instructions = e.Instructions,
                                    IngredientsPrintout = e.Ingredients.Select(c =>
                                    new IngredientInRecipe
                                    {
                                        IngredientName =
                                        ctx
                                            .Ingredients
                                            .Where(f => f.IngredientId == c.Value[0])
                                            .Select(
                                                f => f.Name
                                            ).FirstOrDefault(),
                                        MeasurementName =
                                        ctx
                                            .Measurements
                                            .Where(f => f.MeasurementId == c.Value[1])
                                            .Select(
                                                f => f.Name
                                            ).FirstOrDefault(),
                                        Quantity = c.Value[2]
                                    }).ToList()
                                }
                        );

                return query.ToArray();
            }
        }

        public bool AddIngredientToRecipeById([FromUri] int id, [FromBody] AddIngredientToRecipe model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                int MeasurementId =
                    ctx
                        .Measurements
                        .Where(e => e.Name == model.MeasurementName)
                        .Select(
                            e => e.MeasurementId
                        ).FirstOrDefault();

                int IngredientId =
                    ctx
                        .Ingredients
                        .Where(e => e.Name == model.IngredientName)
                        .Select(
                            e => e.IngredientId
                        ).FirstOrDefault();

                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.RecipeId == id && e.OwnerId == _userId);

                entity.Ingredients.Add((entity.Ingredients.Count() + 1), new List<int> { IngredientId, MeasurementId, model.Quanity });
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
