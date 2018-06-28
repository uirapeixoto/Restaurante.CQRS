namespace Restaurante.Query
{
    public class MesaQuery
    {
        public int MesaId { get; }
        public int PedidoId { get; }

        public MesaQuery(int mesaId, int pedidoId)
        {
            MesaId = mesaId;
            PedidoId = pedidoId;
        }
    }
}
