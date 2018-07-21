using Restaurante.Contract;
using System;

namespace Restaurante.Query.Result
{
    public class GarconsTarefasQueryResult : IQueryResult
    {
        public int GarcomId { get; }
        public string GarcomNome { get; }
        public int PedidoItemId { get; } 
        public int MenuId { get; }
        public string MenuDescricao { get; }
        public bool Bebida { get; }
        public DateTime? AServir { get; }
        public int PedidoId { get; }

        public GarconsTarefasQueryResult(int garcomId, string garcomNome, int pedidoId, int menuId, string menuDescricao, bool bebida, DateTime? aServir)
        {
            GarcomId = garcomId;
            GarcomNome = garcomNome;
            PedidoId = pedidoId;
            MenuId = menuId;
            MenuDescricao = menuDescricao ?? throw new ArgumentNullException(nameof(menuDescricao));
            Bebida = bebida;
            AServir = aServir;
        }
    }
}
