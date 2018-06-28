using System.Collections.Generic;

namespace Restaurante.Query.Result
{
    public class PedidoQueryResult
    {
        public int Id { get; set; }
        public IEnumerable<ItemQueryResult> Itens { get; set; }
    }
}
