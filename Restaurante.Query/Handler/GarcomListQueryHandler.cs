using Restaurante.Contract;
using Restaurante.Infra.Context;
using Restaurante.Query.Query;
using Restaurante.Query.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Query.Handler
{
    public class GarcomListQueryHandler : IQueryHandler<IEnumerable<GarcomQueryResult>>
    {
        private ICafeContext _context;
        public GarcomListQueryHandler(ICafeContext context)
        {
            _context = context;
        }

        public IEnumerable<GarcomQueryResult> Handle()
        {
            return _context.TB_WAITSTAFF
                .AsNoTracking()
                .AsParallel()
                .Select(e => new GarcomQueryResult(
                    e.ID,
                    e.DS_NAME))
                .ToList();
        }
    }
}
