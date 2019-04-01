using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApi.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Category { get; set; }

        public string Image { get; set; }

        public string Body { get; set; }

    }
}
