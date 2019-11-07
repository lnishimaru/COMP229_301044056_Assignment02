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
                    IngredientName = "Egg(s)"
                },
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
                },
                new Ingredient
                {
                    IngredientName = "Butternut Squash"
                },
                new Ingredient
                {
                    IngredientName = "Vegetable broth"
                },
                new Ingredient
                {
                    IngredientName = "Vegetable oil"
                },
                new Ingredient
                {
                    IngredientName = "Curry Powder"
                },
                new Ingredient
                {
                    IngredientName = "Honeycrisp Apple"
                },
                new Ingredient
                {
                    IngredientName = "Almond Milk"
                },
                new Ingredient
                {
                    IngredientName = "Cinnamon"
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
                        IngredientID = 9,
                        Quantity = 1,
                        RecipeID = 1
                    },
                    new IngredientLine
                    {
                        IngredientID = 10,
                        Quantity = 1,
                        RecipeID = 1
                    },
                    new IngredientLine
                    {
                        IngredientID = 11,
                        Quantity = 1,
                        RecipeID = 1
                    },
                    new IngredientLine
                    {
                        IngredientID = 12,
                        Quantity = 1,
                        RecipeID = 1
                    },
                    new IngredientLine
                    {
                        IngredientID = 13,
                        Quantity = 1,
                        RecipeID = 1
                    },
                    new IngredientLine
                    {
                        IngredientID = 14,
                        Quantity = 1,
                        RecipeID = 1
                    },
                    new IngredientLine
                    {
                        IngredientID = 15,
                        Quantity = 1,
                        RecipeID = 1
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
