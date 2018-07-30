using Restaurante.UI.ActionFilters;
using Restaurante.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurante.UI.Controllers
{
    [IncludeLayoutData]
    public class BaseController : Controller
    {
        // GET: Base
        [NonAction]
        protected MesaStatusViewModel AgregarPedidos(IList<PedidoViewModel> pedidos)
        {
            var pedidosAServir = new List<PedidoItemViewModel>();
            var pedidosComidaEmPreparacao = new List<PedidoItemViewModel>();
            var pedidosServidos = new List<PedidoItemViewModel>();


            foreach (var pedido in pedidos)
            {
                foreach (var item in pedido.PedidoBebidaItens.Where(x => !x.Servido.HasValue))
                {
                    pedidosAServir.Add(item);
                }
            }

            foreach (var pedido in pedidos)
            {
                foreach (var item in pedido.PedidoComidaItens.Where(x => x.EmPreparacao.HasValue && !x.Servido.HasValue && !x.MenuItem.Bebida))
                {
                    pedidosComidaEmPreparacao.Add(item);
                }
            }

            foreach (var pedido in pedidos)
            {
                foreach (var item in pedido.PedidoBebidaItens.Where(x => x.Servido.HasValue))
                {
                    pedidosServidos.Add(item);
                }
                foreach (var item in pedido.PedidoComidaItens.Where(x => x.Servido.HasValue))
                {
                    pedidosServidos.Add(item);
                }
            }

            var pedidosItensConsolidados = new MesaStatusViewModel
            {
                PedidosAServir = pedidosAServir,
                PedidosEmPreparacao = pedidosComidaEmPreparacao,
                PedidosServidos = pedidosServidos
            };

            return pedidosItensConsolidados;
        }

    }
}