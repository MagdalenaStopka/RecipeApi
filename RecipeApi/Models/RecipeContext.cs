using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApi.Models
{
    public class RecipeContext : DbContext
    {
        // tworzenie kontekstu z bazy
        public RecipeContext(DbContextOptions<RecipeContext> options) :base(options)
        {

        }
       public DbSet<Recipe> Recipes { get; set; }
    }
}

// update-database
// add-migration init
//add-migration DataAnnotations