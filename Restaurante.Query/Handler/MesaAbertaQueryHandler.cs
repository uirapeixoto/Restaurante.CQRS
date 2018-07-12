﻿using Restaurante.Contract;
using Restaurante.Infra.Context;
using Restaurante.Query.Query;
using Restaurante.Query.Result;
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
            var mesa = _context.TB_TAB_OPENED
                .AsNoTracking()
                .Where(e => e.ID == query.Id && e.ST_ACTIVE)
                .AsParallel()
                .Select(o => new MesaAbertaQueryResult(
                    o.ID,
                    o.NU_TABLE.Value,
                    new GarcomQueryResult(o.TB_WAITSTAFF.ID, o.TB_WAITSTAFF.DS_NAME),
                    o.TB_ORDERED.Select(p => new PedidoQueryResult(
                        p.ID,
                        p.TB_ORDERED_ITEM.Select(i => new PedidoItemQueryResult(
                            i.ID,
                            new MenuItemQueryResult(
                                i.TB_MENU_ITEM.ID,
                                i.TB_MENU_ITEM.NU_MENU_ITEM, 
                                i.DS_DESCRIPTION, 
                                i.TB_MENU_ITEM.ST_IS_DRINK,
                                i.TB_MENU_ITEM.ST_ACTIVE)
                            )))),
                    o.DT_SERVICE,
                    o.ST_ACTIVE
                    )).FirstOrDefault();

            return mesa;
        }
    }
}
