using System.Collections.Generic;

namespace Restaurante.UI.ViewModel
{
    public class MesaStatus
    {
        public int MesaId { get; set; }
        public int NumMesa { get; set; }
        public IEnumerable<PedidoViewModel> PedidosAServir { get; set; }
        public IEnumerable<PedidoViewModel> EmPreparacao { get; set; }
        public IEnumerable<PedidoViewModel> EmSeridos { get; set; }
    }
}