using System.Collections.Generic;

namespace Restaurante.Query.Result
{
    public class MesaQueryResult
    {
        public int NumMesa { get; }
        public IEnumerable<PedidoQueryResult> Pedidos { get; }

        public MesaQueryResult(int numMesa, IEnumerable<PedidoQueryResult> pedidos )
        {
            NumMesa = numMesa;
            Pedidos = pedidos;
        }
    }
}
