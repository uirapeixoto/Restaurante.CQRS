using Restaurante.Contract;
using System;
using System.Collections.Generic;

namespace Restaurante.Query.Result
{
    public class MesaAbertaQueryResult : IQueryResult
    {
        public int Id { get; }
        public int NumMesa { get; }
        public GarcomQueryResult Garcom { get; }
        public IEnumerable<PedidoQueryResult> Pedidos { get; set; }
        public DateTime? DataServico { get; }
        public bool Ativo { get; }

        public MesaAbertaQueryResult(int id, int numMesa, GarcomQueryResult garcom, IEnumerable<PedidoQueryResult> pedidos,DateTime? dataServico, bool ativo)
        {
            Id = id;
            NumMesa = numMesa;
            Garcom = garcom;
            Pedidos = pedidos;
            DataServico = dataServico;
            Ativo = ativo;
        }
    }
}
