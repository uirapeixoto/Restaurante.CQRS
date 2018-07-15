using Restaurante.Command.Mesas.Command;
using Restaurante.Command.Mesas.CommandResult;
using Restaurante.Contract;
using Restaurante.Query.Query;
using Restaurante.Query.Result;
using Restaurante.UI.ActionFilters;
using Restaurante.UI.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Restaurante.UI.Controllers
{
    [IncludeLayoutData]
    public class MesaController : Controller
    {
        readonly IQueryHandler<IEnumerable<GarcomQueryResult>> _garconsListHandler;
        readonly ICommandHandler<AbrirMesaCommand, AbrirMesaCommandResult> _abrirMesaComandHandler;
        readonly IQueryHandler<IEnumerable<MenuItemQueryResult>> _menuItemQueryHandler;
        readonly IQueryHandler<MesaAbertaQuery, MesaAbertaQueryResult> _mesaAbertaQueryHandler;
        readonly ICommandHandler<PedidoCommand> _pedidoCommandHandler;

        public MesaController(
            IQueryHandler<IEnumerable<GarcomQueryResult>> garconsListHandler,
            ICommandHandler<AbrirMesaCommand, AbrirMesaCommandResult> abrirMesaComandHandler,
            IQueryHandler<IEnumerable<MenuItemQueryResult>> menuItemQueryHandler,
            IQueryHandler<MesaAbertaQuery, MesaAbertaQueryResult> mesaAbertaQueryHandler,
            ICommandHandler<PedidoCommand> pedidoCommandHandler)
        {
            _garconsListHandler = garconsListHandler;
            _abrirMesaComandHandler = abrirMesaComandHandler;
            _menuItemQueryHandler = menuItemQueryHandler;
            _mesaAbertaQueryHandler = mesaAbertaQueryHandler;
            _pedidoCommandHandler = pedidoCommandHandler;
        }

        // GET: Mesa
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Abrir()
        {

            var mesa = new MesaAbertaViewModel();

            var result = _garconsListHandler
                .Handle();

            foreach (var garcom in result)
            {
                mesa.Garcons.Add(new GarcomViewModel { Id = garcom.Id, Nome = garcom.Nome });
            }

            return View(mesa);
        }

        [HttpPost]
        public ActionResult Abrir(MesaAbertaViewModel mesa)
        {

            var result = _abrirMesaComandHandler.Handle(new AbrirMesaCommand(mesa.NumMesa,mesa.Garcom.Id));
            var mesaAberta = new MesaAbertaViewModel
            {
                Id = result.Id
            };
            return RedirectToAction("Pedido","Mesa",new { id = mesaAberta.Id });
        }

        public ActionResult Selecionar(int Id)
        {
            return View();
        }

        public ActionResult Pedido(int id)
        {
            var menu = _menuItemQueryHandler.Handle().Select(o => new MenuItemViewModel
            {
                Id = o.Id,
                NumMenuItem = o.NumMenuItem,
                Descricao = o.Descricao,
                Bebida = o.Bebida,
            });

            var pedido = new PedidoViewModel
            {
                MesaId = id,
                PedidoBebidaItens = menu.Where(x => x.Bebida).Select(m => new PedidoItemViewModel {
                    MenuItem = new MenuItemViewModel
                    {
                        Id = m.Id,
                        NumMenuItem = m.NumMenuItem,
                        Descricao = m.Descricao,
                        Bebida = m.Bebida,
                        Ativo = m.Ativo
                    }
                }).ToList(),
                PedidoComidaItens = menu.Where(x => !x.Bebida).Select(m => new PedidoItemViewModel
                {
                    MenuItem = new MenuItemViewModel
                    {
                        Id = m.Id,
                        NumMenuItem = m.NumMenuItem,
                        Descricao = m.Descricao,
                        Bebida = m.Bebida,
                        Ativo = m.Ativo
                    }
                }).ToList()
            };

            return View(pedido);
        }

        [HttpPost]
        public ActionResult Pedido(PedidoViewModel pedido)
        {

            _pedidoCommandHandler.Handle(new PedidoCommand(
                pedido.MesaId, 
                pedido.PedidoBebidaItens.Where(x => x.Quantidade > 0).Select( b => new PedidoItemCommand(
                    b.MenuItem.Id,
                    b.Descricao,
                    b.Quantidade
                    )).ToList(),
                pedido.PedidoComidaItens.Where(x => x.Quantidade > 0).Select(b => new PedidoItemCommand(
                   b.MenuItem.Id,
                   b.Descricao,
                   b.Quantidade
                   )).ToList()
                ));

            return RedirectToAction("Status", new { id = pedido.MesaId });
        }

        [HttpPost]
        public ActionResult Fechar()
        {
            return View();
        }

        public ActionResult Status(int id)
        {
            var mesa = _mesaAbertaQueryHandler.Handle(new MesaAbertaQuery(id));
            var pedidos = mesa.Pedidos.Select(x => new PedidoViewModel
            {
                Id = x.Id,
                PedidoItem = null
            });

            var mesaStatus = new MesaStatusViewModel
            {
               MesaId = mesa.Id,
               NumMesa = mesa.NumMesa
            };

            
            
            return View(mesaStatus);
        }
    }
}