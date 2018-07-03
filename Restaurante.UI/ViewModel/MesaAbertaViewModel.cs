using System.Collections.Generic;

namespace Restaurante.UI.ViewModel
{
    public class MesaAbertaViewModel
    {
        public int Id { get; }
        public GarcomViewModel Garcom { get; }
        public IEnumerable<PedidoViewModel> Pedidos { get; }
        public bool Ativo { get; }

        public MesaAbertaViewModel(int id, GarcomViewModel garcom, IEnumerable<PedidoViewModel> pedidos, bool ativo)
        {
            Id = id;
            Garcom = garcom;
            Pedidos = pedidos;
            Ativo = ativo;
        }
    }
}