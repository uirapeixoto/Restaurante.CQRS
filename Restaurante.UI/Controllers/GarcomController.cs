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
    public class GarcomController : BaseController
    {

        readonly IQueryHandler<GarconsTarefasQuery, IEnumerable<MesaAbertaQueryResult>> _garcomTarefasQueryHandler;

        public GarcomController(IQueryHandler<GarconsTarefasQuery, IEnumerable<MesaAbertaQueryResult>> garcomTarefasQueryHandler)
        {
            _garcomTarefasQueryHandler = garcomTarefasQueryHandler;
        }

        // GET: Garcom
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tarefa(int id)
        {
            var tarefas = _garcomTarefasQueryHandler.Handle(new GarconsTarefasQuery(id))
                .Select(x => new MesaAbertaViewModel {
                    Id = x.Id,
                    NumMesa = x.NumMesa,
                    Garcom = new GarcomViewModel
                    {
                        Id = x.Garcom.Id,
                        Nome = x.Garcom.Nome
                    },
                    DataServico = x.DataServico,
                    Pedidos = x.Pedidos.Select(p => new PedidoViewModel {
                        Id = p.Id,
                        PedidoBebidaItens = p.ItensPedidos.Where(f => f.MenuItem.Bebida).Select(i => new PedidoItemViewModel {
                            Id = i.Id,
                            MenuItem = new MenuItemViewModel
                            {
                                Id = i.MenuItem.Id,
                                NumMenuItem = i.MenuItem.NumMenuItem,
                                Descricao = i.MenuItem.Descricao,
                                Ativo = i.MenuItem.Ativo
                            },
                            AServir = i.AServir,
                            EmPreparacao = i.EmPreparacao,
                            Servido = i.Servido,
                            Quantidade = i.Quantidade,
                            Descricao = i.Descricao,
                        }).ToList(),
                        PedidoComidaItens = p.ItensPedidos.Where(f => !f.MenuItem.Bebida).Select(i => new PedidoItemViewModel
                        {
                            Id = i.Id,
                            MenuItem = new MenuItemViewModel
                            {
                                Id = i.MenuItem.Id,
                                NumMenuItem = i.MenuItem.NumMenuItem,
                                Descricao = i.MenuItem.Descricao,
                                Ativo = i.MenuItem.Ativo
                            },
                            AServir = i.AServir,
                            EmPreparacao = i.EmPreparacao,
                            Servido = i.Servido,
                            Quantidade = i.Quantidade,
                            Descricao = i.Descricao,
                        }).ToList(),
                    }),
                    Ativo = x.Ativo
                });
            
            return View(tarefas);
        }
    }
}