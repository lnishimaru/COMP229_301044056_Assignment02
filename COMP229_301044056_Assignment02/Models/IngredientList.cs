using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP229_301044056_Assignment02.Models
{
    public class IngredientList
    {
        private List<IngredientLine> lineCollection = new List<IngredientLine>();
        public virtual void AddItem(Ingredient ingredient, int quantity)
        {
            IngredientLine line = lineCollection
            .Where(p => p.IngredientID == ingredient.IngredientID)
            .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new IngredientLine
                {
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(Ingredient ingredient) =>
        lineCollection.RemoveAll(l => l.IngredientID == ingredient.IngredientID);
        public virtual void Clear() => lineCollection.Clear();
        public virtual IEnumerable<IngredientLine> Lines => lineCollection;

    }
}
