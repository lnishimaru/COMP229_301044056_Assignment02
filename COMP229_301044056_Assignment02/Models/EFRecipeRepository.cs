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
            //foreach (IngredientLine x in context.IngredientLine)
           // {
            //    context.IngredientLine.Add(x);
           // }
        }
        public IQueryable<Recipe> Recipes => context.Recipes;

        public void SaveRecipe(Recipe recipe)
        {
            System.Diagnostics.Debug.WriteLine("Save Recipe");

            if (recipe.ID == 0)
            {
                context.Recipes.Add(recipe);
                System.Diagnostics.Debug.WriteLine("Adding Recipe");
            }
            else
            {
                Recipe dbEntry = context.Recipes
                .FirstOrDefault(p => p.ID == recipe.ID);
                if (dbEntry != null)
                {
                    dbEntry.ID = 2;
                    dbEntry.Name = recipe.Name;
                    dbEntry.Category = recipe.Category;
                    dbEntry.Cuisine = recipe.Cuisine;
                    dbEntry.Instructions = recipe.Instructions;
                    dbEntry.Lines.Add(new IngredientLine { IngredientLineID = 100, IngredientID = 1, Quantity = 1, MeasureID = 2, RecipeID = 1 });
                    System.Diagnostics.Debug.WriteLine(recipe.Lines);
                } 
            }
            context.SaveChanges();
        }
        public Recipe DeleteRecipe(int recipeID)
        {
            Recipe dbEntry = context.Recipes
            .FirstOrDefault(p => p.ID == recipeID);
            if (dbEntry != null)
            {
                context.Recipes.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
