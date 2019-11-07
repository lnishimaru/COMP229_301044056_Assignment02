using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP229_301044056_Assignment02.Models
{
    public class EFIngredientLineRepository: IIngredientLineRepository
    {
        private ApplicationDbContext context;

        public EFIngredientLineRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<IngredientLine> Lines => context.IngredientLine;
    }
}
