using Restaurante.Command.Cozinha.Command;
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
        readonly ICommandHandler<MarcarComoProntoCommand> _marcarComoProntoCommandHandler;

        public CozinhaController(
            IQueryHandler<CozinhaTarefasQuery, IEnumerable<CozinhaTarefasQueryResult>> cozinhaTarefasQueryHandler,
            ICommandHandler<MarcarComoProntoCommand> marcarComoProntoCommandHandler
        )
        {
            _cozinhaTarefasQueryHandler = cozinhaTarefasQueryHandler;
            _marcarComoProntoCommandHandler = marcarComoProntoCommandHandler;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var result = _cozinhaTarefasQueryHandler.Handle(new CozinhaTarefasQuery(0))
                .Select(o => new CozinhaTarefasViewModel
                {
                    PedidoItemId = o.PedidoItemId,
                    MesaId = o.MesaId,
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

        [HttpPost]
        public ActionResult MarcarComoPronto(IList<CozinhaTarefasViewModel> c)
        {
            try
            {
                foreach (var item in c.Where(x => x.AServir.HasValue))
                {
                    _marcarComoProntoCommandHandler.Handle(new MarcarComoProntoCommand(item.PedidoItemId, item.AServir.Value));
                };
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index");
        }
    }
}