using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeApi.Models;

namespace RecipeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
       
        [HttpGet]
        public IActionResult  GetRecipes()
        {
            return Ok(new List<Recipe>());
           // return "Recipes";
        }

        [HttpGet("{id}")]
        public IActionResult GetRecipes(int id)
        {
            var item = new Recipe
            {
                ID = 1,
                Body = "Oki"
            };
            return Ok(item);
            
        }

        
    }
}