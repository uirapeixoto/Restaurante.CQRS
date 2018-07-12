using System.Collections.Generic;

namespace Restaurante.Dominio
{
    public class Pedido
    {
        public int Id { get; set; }
        public MesaAberta MesaAberta { get; set; }
        public IEnumerable<PedidoItem> PedidosItens { get; set; }
    }
}
