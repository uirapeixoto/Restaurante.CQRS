using Restaurante.Contract;
using System.Collections.Generic;

namespace Restaurante.Query.Result
{
    public class PedidoQueryResult : IQueryResult
    {
        public int Id { get; }
        public IEnumerable<PedidoItemQueryResult> ItensPedidos { get; set; }

        public PedidoQueryResult(int id, IEnumerable<PedidoItemQueryResult> itensPedidos)
        {
            Id = id;
            ItensPedidos = itensPedidos;
        }
    }
}
