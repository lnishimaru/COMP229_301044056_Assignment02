using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using COMP229_301044056_Assignment02.Models;

namespace COMP229_301044056_Assignment02.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
            .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
           if (!context.Ingredients.Any())
            {
                context.Ingredients.AddRange(
                
                new Ingredient
                {
                    IngredientName = "Milk"
                }, new Ingredient
                {
                    IngredientName = "Wheat flour"
                }, new Ingredient
                {
                    IngredientName = "Sugar"
                }, new Ingredient
                {
                    IngredientName = "Salt"
                }, new Ingredient
                {
                    IngredientName = "Pepper"
                }, new Ingredient
                {
                    IngredientName = "Baking powder"
                }, new Ingredient
                {
                    IngredientName = "Onion"
                }
                );
                context.SaveChanges();
            }
            if (!context.Recipes.Any())
            {
                context.Recipes.AddRange(
                new Recipe
                {
                    Name = "Autumn Soup",
                    Category = "Appetizers",
                    Cuisine = "American",
                    Instructions = "Cook the squash with onion apple and almond milk. When softens, put to the food processor."
                });
              context.SaveChanges();
            }
            if (!context.IngredientLine.Any())
            {
                context.IngredientLine.AddRange(

                    new IngredientLine
                    {
                        IngredientID = 1,
                        Quantity = 2,
                        RecipeID = 1
                    },
                    new IngredientLine
                    {
                        IngredientID = 2,
                        Quantity = 1,
                        RecipeID = 1
                    },
                    new IngredientLine
                    {
                        IngredientID =3,
                        Quantity = 1,
                        RecipeID = 1
                    },
                    new IngredientLine
                    {
                        IngredientID = 5,
                        Quantity = 1,
                        RecipeID = 1
                    },
                    new IngredientLine
                    {
                        IngredientID = 6,
                        Quantity = 1,
                        RecipeID = 1
                    },
                    new IngredientLine
                    {
                        IngredientID = 7,
                        Quantity = 1,
                        RecipeID = 1
                    },
                    new IngredientLine
                    {
                        IngredientID = 8,
                        Quantity = 1,
                        RecipeID = 1
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
