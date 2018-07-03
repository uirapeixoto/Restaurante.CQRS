using Restaurante.Contract;
using Restaurante.Dominio.Mesa;
using Restaurante.Query.Result;
using Restaurante.UI.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Restaurante.UI.ActionFilters
{
    public class IncludeLayoutDataAttribute : ActionFilterAttribute
    {
        private IQueryHandler<IEnumerable<GarcomQueryResult>> _garcomListHandler
        {
              get
            {
                return DependencyResolver.Current.GetService<IQueryHandler<IEnumerable<GarcomQueryResult>>>();
            }
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (filterContext.Result is ViewResult)
            {
                var bag = (filterContext.Result as ViewResult).ViewBag;
                bag.Garcons = _garcomListHandler.Handle().AsParallel()
                    .Select(o => new GarcomViewModel
                    {
                        Id = o.Id,
                        Nome = o.Nome
                    }
                );

                bag.MesasAtivas = OpenTabQueries.ActiveTableNumbers;
            }
        }
    }
}