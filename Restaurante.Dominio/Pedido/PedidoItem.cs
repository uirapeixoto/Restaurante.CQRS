using Restaurante.Dominio;

namespace Restaurante.Dominio
{
    public class PedidoItem
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public string Descricao { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
