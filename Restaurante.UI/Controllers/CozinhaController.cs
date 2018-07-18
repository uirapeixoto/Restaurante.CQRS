using Restaurante.Contract;
using Restaurante.Query.Query;
using Restaurante.Query.Result;
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
    public class CozinhaController : Controller
    {
        readonly IQueryHandler<CozinhaTarefasQuery, IEnumerable<CozinhaTarefasQueryResult>> _cozinhaTarefaQueryHandler;
        // GET: Cozinha
        public ActionResult Index(IQueryHandler<CozinhaTarefasQuery, IEnumerable<CozinhaTarefasQueryResult>> cozinhaTarefaQueryHandler)
        {
            var result = _cozinhaTarefaQueryHandler.Handle(new CozinhaTarefasQuery(0)).Select(x => new CozinhaTarefasViewModel
            {
                MesaId = x.MesaId,
                NumMesa = x.NumMesa,
                PedidoId = x.PedidoId,
                MenuItem = new MenuItemViewModel
                {
                    Id = x.MenuItem.Id,
                    NumMenuItem = x.MenuItem.NumMenuItem,
                    Descricao = x.MenuItem.Descricao,
                    Bebida = x.MenuItem.Bebida,
                    Ativo = x.MenuItem.Ativo
                },
                Descricao = x.Descricao,
                Quantidade = x.Quantidade,
                AServir = x.AServir,
                EmPreparacao = x.EmPreparacao,
                Servido = x.Servido,
                AjustePreco = x.AjustePreco
            });

            return View();
        }
    }
}