using Restaurante.Contract;

namespace Restaurante.Query.Query
{
    public sealed class PedidoMesaQuery : IQuery
    {
        public int MesaId { get;  }

        public PedidoMesaQuery(int mesaId)
        {
            MesaId = mesaId;
        }
    }
}
