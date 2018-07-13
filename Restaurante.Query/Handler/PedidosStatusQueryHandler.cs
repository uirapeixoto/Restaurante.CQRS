using Restaurante.Contract;
using Restaurante.Infra.Context;
using Restaurante.Query.Query;
using Restaurante.Query.Result;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurante.Query.Handler
{
    public class PedidosStatusQueryHandler : IQueryHandler<PedidosStatusQuery, IEnumerable<PedidosStatusQueryResult>>
    {
        readonly ICafeContext _context;

        public PedidosStatusQueryHandler(ICafeContext context)
        {
            _context = context;
        }

        public IEnumerable<PedidosStatusQueryResult> Handle(PedidosStatusQuery query)
        {
            var result = _context.TB_ORDERED
                .AsNoTracking()
                .Where(x => x.ID_TAB_OPENED == query.IdMesa)
                .AsParallel()
                .Select(o => new PedidosStatusQueryResult(
                    o.ID,
                    o.TB_TAB_OPENED.NU_TABLE.Value,
                    o.TB_ORDERED_ITEM.Select(i => new PedidoItemQueryResult(
                        i.ID, 
                        new MenuItemQueryResult(
                            i.ID_MENU_ITEM, 
                            i.TB_MENU_ITEM.NU_MENU_ITEM, 
                            i.TB_MENU_ITEM.DS_DESCRIPTION, 
                            i.TB_MENU_ITEM.ST_IS_DRINK, 
                            i.TB_MENU_ITEM.ST_ACTIVE
                            ))))).ToList();

            return result;
        }
    }
}
