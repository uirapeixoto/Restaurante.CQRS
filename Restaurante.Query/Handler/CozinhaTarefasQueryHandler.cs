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
    public class CozinhaTarefasQueryHandler : IQueryHandler<CozinhaTarefasQuery, IEnumerable<CozinhaTarefasQueryResult>>
    {
        readonly ICafeContext _context;

        public CozinhaTarefasQueryHandler(ICafeContext context)
        {
            _context = context;
        }
        public IEnumerable<CozinhaTarefasQueryResult> Handle(CozinhaTarefasQuery query)
        {
            var result = _context.TB_ORDERED_ITEM
                .AsNoTracking()
                .Include(i => i.TB_MENU_ITEM)
                .Include(i => i.TB_ORDERED)
                .Include(i => i.TB_ORDERED.TB_TAB_OPENED)
                .Where(x => !x.TB_MENU_ITEM.ST_IS_DRINK)
                .Where(x => !x.DT_SERVED.HasValue)
                .Where(x => x.DT_IN_PREPARATION.HasValue)
                .AsParallel()
                .Select(o => new CozinhaTarefasQueryResult(
                       o.TB_ORDERED.TB_TAB_OPENED.ID,
                       o.TB_ORDERED.ID,
                       new MenuItemQueryResult(
                           o.TB_MENU_ITEM.ID,
                           o.TB_MENU_ITEM.NU_MENU_ITEM,
                           o.TB_MENU_ITEM.DS_DESCRIPTION,
                           o.TB_MENU_ITEM.ST_IS_DRINK,
                           o.TB_MENU_ITEM.ST_ACTIVE
                        ),
                       o.NU_AMOUNT,
                       o.DT_TO_SERVE,
                       o.DT_IN_PREPARATION,
                       o.DT_SERVED,
                       o.DS_DESCRIPTION
                )).ToList();

            return result;
        }
    }
}
