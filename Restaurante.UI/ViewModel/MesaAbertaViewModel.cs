using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurante.UI.ViewModel
{
    public class MesaAbertaViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Número da Mesa")]
        public int NumMesa { get; set; }
        public GarcomViewModel Garcom { get; set; }
        public IEnumerable<PedidoViewModel> Pedidos { get; set; }
        [Display(Name = "Garçons/Garçonetes")]
        public IList<GarcomViewModel> Garcons { get; set; }
        public bool Ativo { get; set;  }

        public MesaAbertaViewModel()
        {
            Pedidos = new List<PedidoViewModel>();
            Garcons = new List<GarcomViewModel>();
        }
    }
}