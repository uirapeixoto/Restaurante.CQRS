using Restaurante.Contract;
using Restaurante.Infra.Context;
using Restaurante.Query.Query;
using Restaurante.Query.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Query.Handler
{
    public class PedidosMesaQueryHandler : IQueryHandler<PedidoMesaQuery, PedidoMesaQueryResult>
    {
        readonly ICafeContext _context;

        public PedidosMesaQueryHandler(CafeContext context)
        {
            _context = context;
        }

        public PedidoMesaQueryResult Handle(PedidoMesaQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
