using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP229_301044056_Assignment02.Models
{
    public class EFRecipeRepository : IRecipeRepository
    {
        private ApplicationDbContext context;

        public EFRecipeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
            foreach (IngredientLine x in context.IngredientLine)
            {
                context.IngredientLine.Add(x);
            }
        }
        public IQueryable<Recipe> Recipes => context.Recipes;
    }
}
