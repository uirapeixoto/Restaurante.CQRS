using Restaurante.Contract;
using Restaurante.Infra.Context;
using Restaurante.Query.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Restaurante.Query.Handler
{
    public class MesaAbertaListQueryHandler : IQueryHandler<IEnumerable<MesaAbertaQueryResult>>
    {
        private ICafeContext _context;
        public MesaAbertaListQueryHandler(ICafeContext context)
        {
            _context = context;
        }

        public IEnumerable<MesaAbertaQueryResult> Handle()
        {
            var result = _context.TB_TAB_OPENED
                .Include(p => p.TB_ORDERED)
                .Include(g => g.ID_WAITER)
                .AsNoTracking()
                .Where(e => e.ST_ACTIVE)
                .AsParallel()
                .Select(o => new MesaAbertaQueryResult(
                    o.ID,
                    new GarcomQueryResult(o.TB_WAITSTAFF.ID, o.TB_WAITSTAFF.DS_NAME),
                    null,
                    o.ST_ACTIVE
                    )).ToList();

            return result;
        }
    }
}
