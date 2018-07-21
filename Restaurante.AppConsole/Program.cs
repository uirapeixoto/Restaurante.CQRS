using Restaurante.Infra.Context;
using Restaurante.Query.Result;
using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
using System.Data.Entity;
using System.Linq;
>>>>>>> 4f4ac1654bf92ac8514560a4b008d2b9b60ffb34

namespace Restaurante.AppConsole
{
    class Program
    {
<<<<<<< HEAD

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
=======
        static void Main(string[] args)
        {
            using (var _context = new CafeContext())
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

                foreach (var item in result)
                {
                    Console.WriteLine(string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8}",
                        item.MesaId,
                        item.PedidoId,
                        item.MenuItem.NumMenuItem,
                        item.MenuItem.Descricao,
                        item.Quantidade,
                        item.AServir,
                        item.EmPreparacao,
                        item.Servido,
                        item.Descricao
                    ));
>>>>>>> 4f4ac1654bf92ac8514560a4b008d2b9b60ffb34
                }
            }
            Console.ReadKey();
        }
    }
}
