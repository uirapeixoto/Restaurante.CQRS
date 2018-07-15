using Restaurante.Contract;
using System;
using System.Collections.Generic;

namespace Restaurante.Query.Result
{
    public class PedidoMesaQueryResult : IQueryResult
    {
        public int Id { get; }
        public int MesaId { get; }
        public DateTime? DataServico { get; }
        public DateTime? DateServico { get; }
        public IEnumerable<PedidoItemQueryResult> PedidosItens { get; }

        public PedidoMesaQueryResult(int id, int mesaId, DateTime? dataServico, IEnumerable<PedidoItemQueryResult> pedidosItens)
        {
            Id = id;
            MesaId = mesaId;
            DataServico = dataServico;
            PedidosItens = pedidosItens;
        }
    }
}
