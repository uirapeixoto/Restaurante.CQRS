using Restaurante.Contract;
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
        public MesaController(IQueryHandler<IEnumerable<GarcomQueryResult>> garconsListHandler)
        {
            _garconsListHandler = garconsListHandler;
        }

        // GET: Mesa
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Abrir(MesaAbertaViewModel mesa)
        {
            var result = _garconsListHandler
                .Handle();

            foreach (var garcom in result)
            {
                mesa.Garcons.Add(new GarcomViewModel { Id = garcom.Id, Nome = garcom.Nome });
            }

            return View(mesa);
        }

        public ActionResult Status()
        {
            return View();
        }
    }
}