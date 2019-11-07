using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP229_301044056_Assignment02.Models.ViewModels
{
    public class TestViewModel
    {
        public int CurrentRecipeID { get; set; }
        public List<IngredientLine> RecipeIngredients { get; set; }
        public List<string> IngredientName{ get; set; }
    }
}
