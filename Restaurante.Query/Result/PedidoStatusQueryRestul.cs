using Restaurante.Contract;
using System.Collections.Generic;

namespace Restaurante.Query.Result
{
    public class PedidoStatusQueryRestul : IQueryResult
    {
        public int Id { get; }
        public int NumMesa { get; }
        public IEnumerable<PedidoItemQueryResult> ItensPedidos { get; set; }

        public PedidoStatusQueryRestul(int id, int numMesa, IEnumerable<PedidoItemQueryResult> itensPedidos)
        {
            Id = id;
            NumMesa = numMesa;
            ItensPedidos = itensPedidos;
        }
    }
}
