using Restaurante.Contract;
using Restaurante.Infra.Context;
using Restaurante.Query.Query;
using Restaurante.Query.Result;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Restaurante.Query.Handler
{
    
    public class GarconsTarefasQueryHandler : IQueryHandler<GarconsTarefasQuery,IEnumerable<MesaAbertaQueryResult>>
    {
        readonly ICafeContext _context;

        public GarconsTarefasQueryHandler(ICafeContext context)
        {
            _context = context;
        }

        public IEnumerable<MesaAbertaQueryResult> Handle(GarconsTarefasQuery query)
        {
            var mesas = _context.TB_TAB_OPENED
                 .AsNoTracking()
                 .Where(e => e.ST_ACTIVE)
                 .Where(g => g.ID_WAITER == query.Id)
                 .Include(p => p.TB_ORDERED)
                 .Include(p => p.TB_WAITSTAFF)
                 .AsParallel()
                 .Select(o => new MesaAbertaQueryResult(
                         o.ID,
                         o.NU_TABLE.Value,
                         new GarcomQueryResult(o.TB_WAITSTAFF.ID, o.TB_WAITSTAFF.DS_NAME),
                         o.TB_ORDERED.Where(x => x.TB_ORDERED_ITEM.Any()).Select(
                             p => new PedidoQueryResult(
                             p.ID,
                             p.TB_ORDERED_ITEM
                             .Where(x => !x.DT_SERVED.HasValue)
                             .Select(i => new PedidoItemQueryResult(
                                     i.ID,
                                     new MenuItemQueryResult(
                                         i.TB_MENU_ITEM.ID,
                                         i.TB_MENU_ITEM.NU_MENU_ITEM,
                                         i.TB_MENU_ITEM.DS_DESCRIPTION,
                                         i.TB_MENU_ITEM.ST_IS_DRINK,
                                         i.TB_MENU_ITEM.ST_ACTIVE
                                     ),
                                     i.NU_AMOUNT,
                                     i.DT_TO_SERVE,
                                     i.DT_IN_PREPARATION,
                                     i.DT_SERVED,
                                     i.DS_DESCRIPTION
                             ))
                         )),
                         o.DT_SERVICE,
                         o.ST_ACTIVE
                 )).ToList();

            return mesas;
        }
    }
}

