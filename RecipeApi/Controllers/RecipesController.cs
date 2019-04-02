using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeApi.Models;

namespace RecipeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly RecipeContext db;
        public RecipesController(RecipeContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult GetRecipes()
        {
            try
            {
               // throw new Exception("ojej");
                return Ok(db.Recipes.Include(a => a.Category).ToList());
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            //return Ok(new List<Recipe>());
            // return "Recipes";
        }

        [HttpGet("{id}")]
        public IActionResult GetRecipes(int id)
        {
            //var item = new Recipe
            //{
            //    ID = 1,
            //    Body = "Oki"
            //};
            //return Ok(item);

            try
            {

                // throw new Exception("ojej");
                var recipe = db.Recipes.SingleOrDefault(a => a.ID == id);
                if(recipe == null)
                {
                    return NotFound($"Nie znaleziono id:{id}");
                }
                return Ok(recipe);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPost ]
        public IActionResult AddRecipes( Recipe recipe) // musi wiedziec jaki obiekt ma utorzyć/zwrocic [FromBody] piszemy, jak nie ma na gorze [ApiController]
        {
            try
            {
                if(ModelState.IsValid)
                {
                    db.Recipes.Add(recipe);
                    db.SaveChanges();
                    return CreatedAtAction(nameof(GetRecipes), new { id = recipe.ID }, recipe);
                }

                return BadRequest("Błędne dane wejściowe");
                //TODO dodać walidację (z TODO mozemy przejsc bezposrednio z task list

                
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
           // return CreatedAtAction(nameof(GetRecipes), new { id = recipe.ID }, recipe);
        }

        [HttpPut ("{id}")]
        public IActionResult UpDateRecipes(int id, Recipe recipe) // metoda musi miec id i obiekt
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (id < 0)
                    {
                        return BadRequest();
                    }
                }
                //return NoContent();
                var item = db.Recipes.Find(id);
                if(item == null)
                {
                    return NotFound($"Nie znaleziono id:{id}");
                }
                item = recipe;
                db.Update(item);
                db.SaveChanges();
                return Ok(item);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

            //if (id < 0)
            //{
            //    return BadRequest();
            //}
            //return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult<Recipe> DeleteRecipes(int id) // w<> podajemy typ, który będzie zwracany
        {
            try
            {
               

                var item = db.Recipes.Find(id);
                if (item == null)
                {
                    return NotFound($"Nie znaleziono id:{id}");
                }
                db.Update(item);
                db.SaveChanges();
                return Ok(item);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

            //return new Recipe()
            //{
            //    ID = 1,
            //};

        }
    }
}