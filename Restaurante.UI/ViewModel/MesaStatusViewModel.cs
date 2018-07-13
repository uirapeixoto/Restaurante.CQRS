using System.Collections.Generic;

namespace Restaurante.UI.ViewModel
{
    public class MesaStatusViewModel
    {
        public int MesaId { get; set; }
        public int NumMesa { get; set; }
        public IEnumerable<PedidoItemViewModel> PedidosAServir { get; set; }
        public IEnumerable<PedidoItemViewModel> PedidosEmPreparacao { get; set; }
        public IEnumerable<PedidoItemViewModel> PedidosServidos { get; set; }
    }
}