using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COMP229_301044056_Assignment02.Models;
using COMP229_301044056_Assignment02.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace COMP229_301044056_Assignment02.Controllers
{
    public class HomeController : Controller
    {
        private IIngredientRepository repository;
        private IRecipeRepository recipeRepo;
        private IIngredientLineRepository lineRepo;

        public HomeController(IIngredientRepository repoService, IRecipeRepository repoRecipe, IIngredientLineRepository repoLine)
        {
            repository = repoService;
            recipeRepo = repoRecipe;
            lineRepo = repoLine;
        }

        /* public ViewResult Ingredients()
         {
             return View(new TestViewModel
             {
                 Recipe = Recipe
             });
             public ViewResult Ingredients() =>
                View(recipeRepo.Recipes.Where(o => o.ID == 1));
         } */
        public ViewResult Ingredients()
        {
            return View(recipeRepo.Recipes.Where(o => o.ID == 1));
        }

        public ViewResult DisplayPage() =>
            View(recipeRepo.Recipes.Where(o => o.ID == 1));
        public ViewResult Index()
        {
            System.Diagnostics.Debug.WriteLine("carregando a view principal");
            /*foreach (Recipe r in FakeRepository.Recipes)
            {
                System.Diagnostics.Debug.WriteLine(r.Name);
            } */
            return View();
        }
       [HttpGet]
        public ViewResult InsertPage(Recipe recipe)
        {
            return View();
        }
        [HttpPost]
        public ViewResult AddRecipe(Recipe recipe)
        {
            /* if (recipe.Name != null)
            {
                FakeRepository.AddItem(recipe);
            } */
            return View("Index");
        }
        public ViewResult DataPage() =>
            View(recipeRepo.Recipes.Where(o => o.ID > 0));
        /*public ViewResult DataPage()
        {
            return View();
        } */
        /*public ViewResult DisplayPage(int ID)
        {
            System.Diagnostics.Debug.WriteLine("teste!!!!");
            System.Diagnostics.Debug.WriteLine(ID);
            return View(FakeRepository.Recipes);
        }*/

        /*public ActionResult DisplayPage(int ID)
        {
            System.Diagnostics.Debug.WriteLine("teste!!!!");
            System.Diagnostics.Debug.WriteLine(ID);
            ViewBag.RecipeID = ID;
            return View(Recipes);
        } */
        public ViewResult UserPage()
        {
           return View(recipeRepo.Recipes.Where(o => o.ID == 1));
        }

    }

}