using Restaurante.Contract;

namespace Restaurante.Query.Query
{
    public class PedidosStatusQuery : IQuery
    {
        public int IdMesa { get; }
        public int StatusServico { get;  }

        public PedidosStatusQuery(int idMesa, int statusServico)
        {
            IdMesa = idMesa;
            StatusServico = statusServico;
        }
    }
}
