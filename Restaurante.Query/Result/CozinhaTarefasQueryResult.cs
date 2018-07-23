using Restaurante.Contract;
using System;

namespace Restaurante.Query.Result
{
    public class CozinhaTarefasQueryResult : IQueryResult
    {
        public int MesaId { get; }
        public int PedidoId { get; }
        public int PedidoItemId { get; }
        public string Descricao { get; }
        public DateTime? AServir { get; }
        public DateTime? EmPreparacao { get; }
        public DateTime? Servido { get; }
        public MenuItemQueryResult MenuItem { get; }
        public int Quantidade { get; }

        public CozinhaTarefasQueryResult(
        int mesaId,
        int pedidoId,
        int pedidoItemId,
        MenuItemQueryResult menuItem,
         int quantidade,
         DateTime? aServir,
         DateTime? emPreparacao,
         DateTime? servido,
         string descricao)
        {
            MesaId = mesaId;
            PedidoId = pedidoId;
            PedidoItemId = pedidoItemId;
            MenuItem = menuItem;
            Quantidade = quantidade;
            AServir = aServir;
            EmPreparacao = emPreparacao;
            Servido = servido;
            Descricao = descricao;
        }

    }
}
