using System.ComponentModel.DataAnnotations;

namespace Restaurante.UI.ViewModel
{
    public class PedidoItemViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Numero Menu")]
        public MenuItemViewModel MenuItem { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Ajuste")]
        public decimal Ajuste { get; set; }

    }
}