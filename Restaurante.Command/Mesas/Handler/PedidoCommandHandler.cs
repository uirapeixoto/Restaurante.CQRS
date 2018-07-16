using Restaurante.Command.Mesas.Command;
using Restaurante.Contract;
using Restaurante.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Command.Mesas.Handler
{
    public class PedidoCommandHandler : ICommandHandler<PedidoCommand>
    {
        readonly ICafeContext _context;

        public PedidoCommandHandler(ICafeContext context)
        {
            _context = context;
        }

        public void Handle(PedidoCommand c)
        {

            var listaPedidosComida = c.PedidosComidaItens.Select(x => new TB_ORDERED_ITEM
            {
                  DS_DESCRIPTION = x.Descricao,
                  NU_AMOUNT = x.Quantidade,
                  DT_TO_SERVE = x.AServir,
                  DT_IN_PREPARATION = DateTime.Now,
                  ID_MENU_ITEM = x.MenuId,
                  DT_SERVICE = x.DataServico
            });

            var listaPedidosBebida = c.PedidosBebidaItens.Select(x => new TB_ORDERED_ITEM
            {
                DS_DESCRIPTION = x.Descricao,
                NU_AMOUNT = x.Quantidade,
                DT_TO_SERVE = DateTime.Now,
                ID_MENU_ITEM = x.MenuId,
                DT_SERVICE = x.DataServico
            });

            IList<TB_ORDERED_ITEM> listaConcatenada = new List<TB_ORDERED_ITEM>();
            foreach (var item in listaPedidosBebida)
            {
                listaConcatenada.Add(item);
            }

            foreach (var item in listaPedidosComida)
            {
                listaConcatenada.Add(item);
            }

            var table = new TB_ORDERED
            {
                ID_TAB_OPENED = c.MesaId,
                DT_SERVICE = DateTime.Now,
                TB_ORDERED_ITEM = listaConcatenada
            };

            _context.TB_ORDERED.Add(table);
            var id = _context.SaveChanges();
        }
    }
}
