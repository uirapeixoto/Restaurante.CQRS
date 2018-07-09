using System.ComponentModel.DataAnnotations;

namespace Restaurante.UI.ViewModel
{
    public class MenuItemViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Número")]
        public int NumMenuItem { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public bool Bebida { get; set; }
        public bool Ativo { get; set; }
    }
}