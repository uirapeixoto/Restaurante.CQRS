using Restaurante.Contract;
using Restaurante.Dominio;
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

        private IQueryHandler<IEnumerable<MesaAbertaQueryResult>> _mesasAbertas
        {
            get
            {
                return DependencyResolver.Current.GetService<IQueryHandler<IEnumerable<MesaAbertaQueryResult>>>();
            }
            
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (filterContext.Result is ViewResult)
            {
                var bag = (filterContext.Result as ViewResult).ViewBag;
                var garcons = _garcomListHandler.Handle().AsParallel()
                    .Select(o => new GarcomViewModel
                    {
                        Id = o.Id,
                        Nome = o.Nome
                    }
                );
                var list = new List<string>();

                foreach (var item in garcons)
                {
                    list.Add(item.Nome);
                }

                var mesas = _mesasAbertas.Handle();
                var listaMesas = new Dictionary<int, int>();

                foreach (var item in mesas)
                {
                    listaMesas.Add(item.Id, item.NumMesa);
                }

                bag.Garcons = garcons;
                bag.GarconsStr = list;
                bag.ActiveTables = listaMesas;
            bag.MesasAtivas = OpenTabQueries.ActiveTableNumbers;
            }
        }

    }
}