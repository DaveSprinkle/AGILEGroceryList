using AGILEGroceryList.Data;
using AGILEGroceryList.Models;
using AGILEGroceryList.Models.IngredientModels;
using AGILEGroceryList.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        //CRUD METHODS

        //========CREATE========//





    }
}
