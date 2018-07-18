using Restaurante.Contract;
using Restaurante.Infra.Context;
using Restaurante.Query.Query;
using Restaurante.Query.Result;
using System;
using System.Collections.Generic;
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
                .Where(x => x.DT_IN_PREPARATION.HasValue)
                .Where(x => !x.TB_MENU_ITEM.ST_IS_DRINK)
                .Select(o => new CozinhaTarefasQueryResult(
                    o.TB_ORDERED.TB_TAB_OPENED.ID,
                    o.TB_ORDERED.TB_TAB_OPENED.NU_TABLE.Value,
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
                    ));

            return result;
        }
    }
}
