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

        public MesaController(
            IQueryHandler<IEnumerable<GarcomQueryResult>> garconsListHandler,
            ICommandHandler<AbrirMesaCommand, AbrirMesaCommandResult> abrirMesaComandHandler,
            IQueryHandler<IEnumerable<MenuItemQueryResult>> menuItemQueryHandler,
            IQueryHandler<MesaAbertaQuery, MesaAbertaQueryResult> mesaAbertaQueryHandler)
        {
            _garconsListHandler = garconsListHandler;
            _abrirMesaComandHandler = abrirMesaComandHandler;
            _menuItemQueryHandler = menuItemQueryHandler;
            _mesaAbertaQueryHandler = mesaAbertaQueryHandler;
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
            return RedirectToAction("Pedido","Mesa",mesaAberta.Id);
        }

        public ActionResult Selecionar(int Id)
        {
            return View();
        }

        public ActionResult Pedido()
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
                PedidoItens = menu.Select(m => new PedidoItemViewModel {
                    MenuItem = new MenuItemViewModel
                    {
                        Id = m.Id,
                        NumMenuItem = m.NumMenuItem,
                        Descricao = m.Descricao,
                        Bebida = m.Bebida,
                        Ativo = m.Ativo
                    }
                })
            };

            return View(pedido);
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