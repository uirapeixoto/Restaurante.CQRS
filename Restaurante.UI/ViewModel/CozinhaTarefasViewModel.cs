using System;

namespace Restaurante.UI.ViewModel
{
    public class CozinhaTarefasViewModel
    {
        public int MesaId { get; set; }
        public int NumMesa { get; set; }
        public int PedidoId { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal AjustePreco { get; set; }
        public DateTime? AServir { get; set; }
        public DateTime? EmPreparacao { get; set; }
        public DateTime? Servido { get; set; }
        public MenuItemViewModel MenuItem { get; set; }
    }
}