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
        private readonly IIngredientRepository repository;
        private IRecipeRepository recipeRepo;
        private IIngredientLineRepository lineRepo;
        private IMeasureRepository measureRepo;

        public HomeController(IIngredientRepository repoService, IRecipeRepository repoRecipe, IIngredientLineRepository repoLine, IMeasureRepository repoMeasure)
        {
            repository = repoService;
            recipeRepo = repoRecipe;
            lineRepo = repoLine;
            measureRepo = repoMeasure;
        }
        public ViewResult Ingredients()
        {
            TestViewModel test2 = new TestViewModel();
            test2.Line = new List<IngredientLineDetail>();
            Measure test4 = new Measure();

            var query = from p in recipeRepo.Recipes
                        where p.ID == 1
                        orderby p.ID
                        select p;

            foreach (var recipe in query)
            {
                test2.Name = recipe.Name;
                test2.Instructions = recipe.Instructions;
                test2.ID = recipe.ID;
                test2.Category = recipe.Category;
                test2.Cuisine = recipe.Cuisine;
                
                
                    System.Diagnostics.Debug.WriteLine(recipe.Name);
                var query2 = from q in lineRepo.Lines
                             where q.RecipeID == recipe.ID
                             orderby q.IngredientLineID
                             select q;

                foreach (var line in query2)
                {     
                    System.Diagnostics.Debug.WriteLine(line.IngredientID);
                    var query4 = from s in measureRepo.Measures
                                 where s.MeasureID == line.MeasureID
                                 select s;

                    foreach (var o in query4)
                    {
                        System.Diagnostics.Debug.WriteLine(o.MeasureDesc);
                        test4 = new Measure { MeasureID = o.MeasureID, MeasureDesc = o.MeasureDesc };
                    }
                    var query3 = from r in repository.Ingredients
                                 where r.IngredientID == line.IngredientID
                                 select r;
                    
                    foreach (var m in query3)
                    {
                        System.Diagnostics.Debug.WriteLine(m.IngredientName);
                        test2.Line.Add(new IngredientLineDetail
                        {
                            IngredientLineID = line.IngredientLineID,
                            Quantity = line.Quantity,
                            Measure =  new Measure { MeasureID = test4.MeasureID, MeasureDesc = test4.MeasureDesc },
                            RecipeID = line.RecipeID,
                            Ingredient = new Ingredient
                            {
                                IngredientID = line.IngredientID,
                                IngredientName = m.IngredientName
                            }
                        });
                    }
                }   
            }

            return View(test2);
        }
        public ViewResult DisplayPage(int recipeID)
        {
            TestViewModel test2 = new TestViewModel();
            test2.Line = new List<IngredientLineDetail>();
            Measure test4 = new Measure();

            var query = from p in recipeRepo.Recipes
                        where p.ID == recipeID
                        orderby p.ID
                        select p;

            foreach (var recipe in query)
            {
                test2.Name = recipe.Name;
                test2.Instructions = recipe.Instructions;
                test2.ID = recipe.ID;
                test2.Category = recipe.Category;
                test2.Cuisine = recipe.Cuisine;


                System.Diagnostics.Debug.WriteLine(recipe.Name);
                var query2 = from q in lineRepo.Lines
                             where q.RecipeID == recipe.ID
                             orderby q.IngredientLineID
                             select q;

                foreach (var line in query2)
                {
                    System.Diagnostics.Debug.WriteLine(line.IngredientID);
                    var query4 = from s in measureRepo.Measures
                                 where s.MeasureID == line.MeasureID
                                 select s;

                    foreach (var o in query4)
                    {
                        System.Diagnostics.Debug.WriteLine(o.MeasureDesc);
                        test4 = new Measure { MeasureID = o.MeasureID, MeasureDesc = o.MeasureDesc };
                    }
                    var query3 = from r in repository.Ingredients
                                 where r.IngredientID == line.IngredientID
                                 select r;

                    foreach (var m in query3)
                    {
                        System.Diagnostics.Debug.WriteLine(m.IngredientName);
                        test2.Line.Add(new IngredientLineDetail
                        {
                            IngredientLineID = line.IngredientLineID,
                            Quantity = line.Quantity,
                            Measure = new Measure { MeasureID = test4.MeasureID, MeasureDesc = test4.MeasureDesc },
                            RecipeID = line.RecipeID,
                            Ingredient = new Ingredient
                            {
                                IngredientID = line.IngredientID,
                                IngredientName = m.IngredientName
                            }
                        });
                    }
                }
            }
            return View(test2);
        }
        public ViewResult Index()
        {
            return View();
        }
        public ViewResult InsertPage() =>
            View();

        [HttpPost]
        public IActionResult InsertPage(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                recipeRepo.SaveRecipe(recipe);
                TempData["message"] = $"{recipe.Name} has been saved";
                return View();
            }
            else
            {
                return View(recipe);
            }
        }
        [HttpPost]
        public ViewResult AddRecipe(Recipe recipe)
        {
            recipeRepo.SaveRecipe(recipe);
            TempData["message"] = $"{recipe.Name} has been saved";
            return View();           
        }
        public ViewResult DataPage() =>
            View(recipeRepo.Recipes.Where(o => o.ID > 0));
       
        public ViewResult UserPage()
        {
           return View(recipeRepo.Recipes.Where(o => o.ID == 1));
        }
        [HttpPost]
        public IActionResult Delete(int ID)
        {
            Recipe deletedRecipe = recipeRepo.DeleteRecipe(ID);
            if (deletedRecipe != null)
            {
                TempData["message"] = $"{deletedRecipe.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
        public ViewResult Edit(int ID)
        {
            TestViewModel test2 = new TestViewModel();
            test2.Line = new List<IngredientLineDetail>();
            Measure test4 = new Measure();

            var query = from p in recipeRepo.Recipes
                        where p.ID == ID
                        orderby p.ID
                        select p;

            foreach (var recipe in query)
            {
                test2.Name = recipe.Name;
                test2.Instructions = recipe.Instructions;
                test2.ID = recipe.ID;
                test2.Category = recipe.Category;
                test2.Cuisine = recipe.Cuisine;


                System.Diagnostics.Debug.WriteLine(recipe.Name);
                var query2 = from q in lineRepo.Lines
                             where q.RecipeID == recipe.ID
                             orderby q.IngredientLineID
                             select q;

                foreach (var line in query2)
                {
                    System.Diagnostics.Debug.WriteLine(line.IngredientID);
                    var query4 = from s in measureRepo.Measures
                                 where s.MeasureID == line.MeasureID
                                 select s;

                    foreach (var o in query4)
                    {
                        System.Diagnostics.Debug.WriteLine(o.MeasureDesc);
                        test4 = new Measure { MeasureID = o.MeasureID, MeasureDesc = o.MeasureDesc };
                    }
                    var query3 = from r in repository.Ingredients
                                 where r.IngredientID == line.IngredientID
                                 select r;

                    foreach (var m in query3)
                    {
                        System.Diagnostics.Debug.WriteLine(m.IngredientName);
                        test2.Line.Add(new IngredientLineDetail
                        {
                            IngredientLineID = line.IngredientLineID,
                            Quantity = line.Quantity,
                            Measure = new Measure { MeasureID = test4.MeasureID, MeasureDesc = test4.MeasureDesc },
                            RecipeID = line.RecipeID,
                            Ingredient = new Ingredient
                            {
                                IngredientID = line.IngredientID,
                                IngredientName = m.IngredientName
                            }
                        });
                    }
                }
            }
            return View(test2);
        }
    }

}