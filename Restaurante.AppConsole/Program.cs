using Restaurante.Infra.Context;
using Restaurante.Query.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.AppConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            using (var context = new CafeContext())
            {
                var mesas = context.TB_ORDERED_ITEM
                    .AsNoTracking()
                    .Where(x => !x.TB_MENU_ITEM.ST_IS_DRINK)
                    .Where(x => x.DT_IN_PREPARATION.HasValue)
                    .Where(x => !x.DT_SERVED.HasValue)
                    .AsParallel()
                    .Select(o => new
                    {
                        MesaId = o.TB_ORDERED.ID_TAB_OPENED,
                        PedidoId = o.TB_ORDERED.ID,

                        //MenuItem = new MenuItemQueryResult(
                        //    o.TB_MENU_ITEM.ID,
                        //    o.TB_MENU_ITEM.NU_MENU_ITEM,
                        //    o.TB_MENU_ITEM.DS_DESCRIPTION,
                        //    o.TB_MENU_ITEM.ST_IS_DRINK,
                        //    o.TB_MENU_ITEM.ST_ACTIVE
                        //),
                        MenuId = o.TB_MENU_ITEM.ID,
                        MenuNum = o.TB_MENU_ITEM.NU_MENU_ITEM,
                        MenuDescricao = o.TB_MENU_ITEM.DS_DESCRIPTION,
                        MenuBebida = o.TB_MENU_ITEM.ST_IS_DRINK,
                        MenuAtivo = o.TB_MENU_ITEM.ST_ACTIVE
                                    ,
                        Quantidade = o.NU_AMOUNT,
                        AServir = o.DT_TO_SERVE,
                        EmPreparacao = o.DT_IN_PREPARATION,
                        Servido = o.DT_SERVED,
                        Ajuste = (o.NU_PRICE_ADJUSTIMENT != null) ? o.NU_PRICE_ADJUSTIMENT : (decimal)0.0,
                        Descricao = o.DS_DESCRIPTION
                    }
                ).ToList();
                foreach (var item in mesas)
                {
                    Console.WriteLine(string.Format("{0} - {1} - {2} - {3} - {4} - {5} - {6} - {7} - {8} - {9}",
                        item.MesaId,
                        item.PedidoId,
                            item.MenuItem.Id,
                            item.MenuItem.NumMenuItem,
                            item.MenuItem.Descricao,
                            item.MenuItem.Bebida,
                            item.MenuItem.Ativo,
                        item.AServir,
                        item.EmPreparacao,
                        item.Servido));
                }
            }
            Console.ReadKey();
        }
    }
}
