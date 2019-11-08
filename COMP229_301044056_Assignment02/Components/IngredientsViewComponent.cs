using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using COMP229_301044056_Assignment02.Models;
using COMP229_301044056_Assignment02.Models.ViewModels;

namespace COMP229_301044056_Assignment02.Components
{
    public class IngredientsViewComponent: ViewComponent
    {
        private IIngredientRepository repository;
        private IIngredientLineRepository ingrLine;
        public IngredientsViewComponent(IIngredientRepository repo, IIngredientLineRepository rep2)
        {
            repository = repo;
            ingrLine = rep2;
        }
        public IViewComponentResult Invoke(int recipeID)
        {

            return View(new TestViewModel
            {
                /* Line = ingrLine.Lines
                    .Where(p => p.RecipeID == recipeID)
                    .OrderBy(p => p.RecipeID).ToList()
                , */
                ID = recipeID
            });
        }
    }

    /*
     return View(repository.Ingredients
    .Select(x => x.IngredientName)
    .Distinct()
    .OrderBy(x => x)); */
}
