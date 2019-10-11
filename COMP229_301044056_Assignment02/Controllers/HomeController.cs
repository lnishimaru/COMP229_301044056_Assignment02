using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COMP229_301044056_Assignment02.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP229_301044056_Assignment02.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            System.Diagnostics.Debug.WriteLine("carregando a view principal");
            foreach (Recipe r in FakeRepository.Recipes)
            {
                System.Diagnostics.Debug.WriteLine(r.Name);
            }
            //return View(FakeRepository.Recipes); 
            return View();
        }
       [HttpGet]
        public ViewResult InsertPage(Recipe recipe)
        {
            recipe.ID = 1001;
            recipe.Category = "Test";
            recipe.Ingredients = "Heavy cream, Unflavored gelatin, Milk , White Sugar, Vanilla extract";
            System.Diagnostics.Debug.WriteLine("Second Step");
            return View();
        }
        [HttpPost]
        public ViewResult AddRecipe(Recipe recipe)
        {
            System.Diagnostics.Debug.WriteLine("1.Saving  recipe?");
            System.Diagnostics.Debug.WriteLine(recipe.Name);
            FakeRepository.AddItem(recipe);
            foreach(Recipe r in FakeRepository.Recipes)
            {
                System.Diagnostics.Debug.WriteLine(r.Name);
            }
            return View("Index");
        } 
    }

}