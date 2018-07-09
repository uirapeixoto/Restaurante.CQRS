using Restaurante.Contract;
using Restaurante.Infra.Context;
using Restaurante.Query.Result;
using System.Collections.Generic;
using System.Linq;

namespace Restaurante.Query.Handler
{
    public class MenuListQueryHandler : IQueryHandler<IEnumerable<MenuItemQueryResult>>
    {

        readonly ICafeContext _context;

        public MenuListQueryHandler(ICafeContext context)
        {
            _context = context;
        }

        public IEnumerable<MenuItemQueryResult> Handle()
        {
            return _context.TB_MENU_ITEM.AsNoTracking().Where(x => x.ST_ACTIVE).AsParallel().Select(x => new MenuItemQueryResult(
                    x.ID,
                    x.NU_MENU_ITEM,
                    x.DS_DESCRIPTION,
                    x.ST_IS_DRINK,
                    x.ST_ACTIVE
                )).ToList();
        }
    }
}
