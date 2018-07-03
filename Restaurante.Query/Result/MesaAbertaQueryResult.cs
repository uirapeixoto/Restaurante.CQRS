using Restaurante.Contract;
using System.Collections.Generic;

namespace Restaurante.Query.Result
{
    public class MesaAbertaQueryResult : IQueryResult
    {
        public int Id { get; }
        public GarcomQueryResult Garcom { get; }
        public IEnumerable<PedidoQueryResult> Pedidos { get; }
        public bool Ativo { get; }

        public MesaAbertaQueryResult(int id, GarcomQueryResult garcom, IEnumerable<PedidoQueryResult> pedidos, bool ativo)
        {
            Id = id;
            Garcom = garcom;
            Pedidos = pedidos;
            Ativo = ativo;
        }
    }
}
