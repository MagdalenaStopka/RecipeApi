using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RecipeApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApi.Models
{
    public class RecipeContext : DbContext
    {
        public RecipeContext()
        {

        }
       
        // tworzenie kontekstu z bazy
        public RecipeContext(DbContextOptions<RecipeContext> options) :base(options)
        {

        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            optionsBuilder.UseSqlite(StaticValues.ConnectionHelper);
            //optionsBuilder.UseSqlite("FileName=./Data/Recipes.db"); //Przekazać w inny sposób.

        }
        public DbSet<Recipe> Recipes { get; set; }
       public DbSet<Category> Categories { get; set; }
       public DbSet<Key> Keys { get; set; }
        public string ConnectionName { get; }
    }
}

// update-database
// add-migration init
//add-migration DataAnnotations
//add-migration Category