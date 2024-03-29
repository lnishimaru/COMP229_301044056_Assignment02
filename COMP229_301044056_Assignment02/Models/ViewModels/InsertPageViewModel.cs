﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP229_301044056_Assignment02.Models.ViewModels
{
    public class InsertPageViewModel
    {
        public Recipe RecipeVM { get; set; }
        public List<IngredientLineDetail> CollectLine { get; set; }
        public IngredientLine Line { get; set; }
        public List<Ingredient> Ingredient { get; set; }
        public List<Measure> Measure { get; set; }
        public InsertPageViewModel()
        {
            RecipeVM = new Recipe();
            RecipeVM.Lines = new List<IngredientLine>();
            CollectLine = new List<IngredientLineDetail>();
            Line = new IngredientLine();
            Ingredient = new List<Ingredient>();
            Measure = new List<Measure>();
        }
    }
}
