using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP229_301044056_Assignment02.Models
{
    public class EFMeasuresRepository: IMeasureRepository
    {
        private ApplicationDbContext context;

        public EFMeasuresRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Measure> Measures => context.Measures;
    }
}
