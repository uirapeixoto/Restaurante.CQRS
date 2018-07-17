using Restaurante.Contract;
using Restaurante.Infra.Context;
using Restaurante.Query.Query;
using Restaurante.Query.Result;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurante.Query.Handler
{
    public class CozinhaTarefasQueryHandler : IQueryHandler<CozinhaTarefasQuery, IEnumerable<PedidosStatusQueryResult>>
    {
        readonly ICafeContext _context;

        public CozinhaTarefasQueryHandler(ICafeContext context)
        {
            _context = context;
        }
        public IEnumerable<PedidosStatusQueryResult> Handle(CozinhaTarefasQuery query)
        {
            var result = _context.TB_ORDERED
                .AsNoTracking()
                .AsParallel()
                .Select(o => new PedidosStatusQueryResult(
                    o.ID,
                    o.TB_TAB_OPENED.NU_TABLE.Value,
                    o.TB_ORDERED_ITEM
                    .Where(x => x.DT_IN_PREPARATION.HasValue)
                    .Where(x => !x.TB_MENU_ITEM.ST_IS_DRINK)
                    .Select(i => new PedidoItemQueryResult(
                        i.ID,
                        new MenuItemQueryResult(
                            i.ID_MENU_ITEM,
                            i.TB_MENU_ITEM.NU_MENU_ITEM,
                            i.TB_MENU_ITEM.DS_DESCRIPTION,
                            i.TB_MENU_ITEM.ST_IS_DRINK,
                            i.TB_MENU_ITEM.ST_ACTIVE
                            ),
                        i.NU_AMOUNT,
                        i.DT_TO_SERVE,
                        i.DT_IN_PREPARATION,
                        i.DT_SERVED)
                    ))).ToList();

            return result;
        }
    }
}
