using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using COMP229_301044056_Assignment02.Models;

namespace COMP229_301044056_Assignment02.Controllers
{
    public class AdminController : Controller
    {
        private IRecipeRepository repository;
        public AdminController(IRecipeRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index() => View(repository.Recipes);
        public ViewResult Edit(int ID) =>
            View(repository.Recipes
            .FirstOrDefault(p => p.ID == ID));

        [HttpPost]
        public IActionResult Edit(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                repository.SaveRecipe(recipe);
                TempData["message"] = $"{recipe.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(recipe);
            }
        }
        public ViewResult Create() => View("Edit", new Recipe());

        [HttpPost]
        public IActionResult Delete(int recipeId)
        {
            Recipe deletedRecipe = repository.DeleteRecipe(recipeId);
            if (deletedRecipe != null)
            {
                TempData["message"] = $"{deletedRecipe.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
    }
}