﻿using AGILEGroceryList.Data;
using AGILEGroceryList.Models;
using AGILEGroceryList.Models.GroceryList;
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
    public class GroceryService
    {
        //set a private field for the user Id
        private readonly Guid _userId;

        //create a private context
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public GroceryService(Guid userId)
        {
            _userId = userId;
        }

        //Create a grocery list
        public async Task<bool> CreateGroceryList(GroceryCreate model)
        {
            var entity =
                new GroceryList()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                };

            _context.GroceryLists.Add(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        //Get grocery list
        public async Task<List<GroceryListItem>> GetGroceryLists()
        {
            var query =
                await
                _context
                .GroceryLists
                .Where(e => e.OwnerId == _userId)
                .Select(
                    e =>
                    new GroceryListItem()
                    {
                        GroceryListId = e.GroceryListId,
                        OwnerId = e.OwnerId,
                        Name = e.Name,
                        Ingredients = _context.Ingredients.Where(i => i.GroceryListId == e.GroceryListId)
                        .Select(
                            gi =>
                            new ListIngredient()
                            {
                                IngredientId = gi.IngredientId,
                                Name = gi.Name
                            }
                            ).ToList()
                    }).ToListAsync();
            return query;
        }

        //Get grocery by id
        public async Task<List<GroceryListItem>> GetGroceryListById(int id)
        {
            var query =
                await
                _context
                .GroceryLists
                .Where(e => e.GroceryListId == id && e.OwnerId == _userId)
                .Select(
                    e =>
                    new GroceryListItem
                    {
                        GroceryListId = e.GroceryListId,
                        OwnerId = e.OwnerId,
                        Name = e.Name,
                        Ingredients = _context.Ingredients.Where(i => i.GroceryListId == e.GroceryListId)
                        .Select(ing => 
                            new ListIngredient
                            {
                                IngredientId = ing.IngredientId,
                                Name = ing.Name
                            }
                        ).ToList()
                    }
                    ).ToListAsync();

            return query;
        }


        //Update grocery by id
        public async Task<bool> UpdateGroceryListById([FromUri]int id, [FromBody] GroceryEdit model)
        {
            var entity =
                _context
                .GroceryLists
                .Single(e => e.GroceryListId == id && e.OwnerId == _userId);
            entity.Name = model.Name;

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteGroceryListById([FromUri] int id)
        {
            var entity =
                _context
                .GroceryLists
                .Single(e => e.GroceryListId == id && e.OwnerId == _userId);

            _context.GroceryLists.Remove(entity);

            return await _context.SaveChangesAsync() == 1;
        }
    }
}
