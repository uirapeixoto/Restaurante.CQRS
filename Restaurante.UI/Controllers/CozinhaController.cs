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
    public class CozinhaController : BaseController
    {
        readonly IQueryHandler<CozinhaTarefasQuery, IEnumerable<CozinhaTarefasQueryResult>> _cozinhaTarefasQueryHandler;
        public CozinhaController(IQueryHandler<CozinhaTarefasQuery, IEnumerable<CozinhaTarefasQueryResult>> cozinhaTarefasQueryHandler)
        {
            _cozinhaTarefasQueryHandler = cozinhaTarefasQueryHandler;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var result = _cozinhaTarefasQueryHandler.Handle(new CozinhaTarefasQuery(0))
                .Select(o => new CozinhaTarefasViewModel {
                    MesaId = o.MesaId,
                    NumMesa = o.NumMesa,
                    PedidoId = o.PedidoId,
                    MenuItem = new MenuItemViewModel
                    {
                        Id = o.MenuItem.Id,
                        NumMenuItem = o.MenuItem.NumMenuItem,
                        Descricao = o.MenuItem.Descricao,
                        Bebida = o.MenuItem.Bebida,
                        Ativo = o.MenuItem.Ativo
                    },
                    Quantidade = o.Quantidade,
                    Descricao = o.Descricao,
                    AServir = o.AServir,
                    EmPreparacao = o.EmPreparacao,
                    Servido = o.Servido
                }).ToList();

            return View(result);
        }
    }
}