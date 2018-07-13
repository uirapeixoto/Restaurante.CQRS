using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurante.UI.ViewModel
{
    public class PedidoViewModel
    {
        public int Id { get; set; }
        public PedidoItemViewModel PedidoItem { get; set; }

        public IEnumerable<PedidoItemViewModel> PedidoItens { get; set; }

        public PedidoViewModel()
        {
            PedidoItens = new List<PedidoItemViewModel>();
        }
    }
}