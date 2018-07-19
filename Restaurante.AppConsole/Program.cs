using Restaurante.Infra.Context;
using Restaurante.Query.Result;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var _context = new CafeContext())
            {
                var result = _context.TB_TAB_OPENED
                 .AsNoTracking()
                 .Where(e => e.ST_ACTIVE)
                 .Where(g => g.ID_WAITER == 1)
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
                Console.WriteLine(result);
            }
            Console.ReadKey();
        }
    }
}
