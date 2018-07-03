using Restaurante.Contract;
using Restaurante.Infra.Context;
using Restaurante.Query.Result;
using System;
using System.Collections.Generic;
using System.Linq;

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
            try
            {
                var result = _context.TB_WAITSTAFF
                                .AsNoTracking()
                                .AsParallel()
                                .Select(e => new GarcomQueryResult(
                                    e.ID,
                                    e.DS_NAME))
                                .ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
