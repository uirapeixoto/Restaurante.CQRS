using Restaurante.Contract;

namespace Restaurante.Query.Result
{
    public class PedidoQueryResult : IQueryResult
    {
        public int Id { get; }
        public MesaAbertaQueryResult MesaAberta { get; }
        public PedidoItemQueryResult PedidoItem { get;  }

        public PedidoQueryResult(int id, MesaAbertaQueryResult mesaAberta, PedidoItemQueryResult pedidoItem)
        {
            Id = id;
            MesaAberta = mesaAberta;
            PedidoItem = pedidoItem;
        }
    }
}
