using Restaurante.Contract;
using Restaurante.Infra.Context;
using Restaurante.Query.Query;
using Restaurante.Query.Result;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Restaurante.Query.Handler
{
    public class MesaAbertaQueryHandler : IQueryHandler<MesaAbertaQuery, MesaAbertaQueryResult>
    {
        private ICafeContext _context;
        public MesaAbertaQueryHandler(ICafeContext context)
        {
            _context = context;
        }
        public MesaAbertaQueryResult Handle(MesaAbertaQuery query)
        {
            var result = _context.TB_TAB_OPENED
                .Include(p => p.TB_ORDERED)
                .Include(g => g.ID_WAITER)
                .AsNoTracking()
                .Where(e => e.ID == query.Id && e.ST_ACTIVE)
                .AsParallel()
                .Select(o => new MesaAbertaQueryResult(
                    o.ID,
                    o.NU_TABLE.Value,
                    new GarcomQueryResult(o.TB_WAITSTAFF.ID, o.TB_WAITSTAFF.DS_NAME),
                    null,
                    o.ST_ACTIVE
                    )).FirstOrDefault();

            return result;
        }
    }
}
