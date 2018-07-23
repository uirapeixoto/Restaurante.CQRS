using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurante.UI.ViewModel
{
    public class CozinhaTarefasViewModel
    {
        [Display(Name = "Id")]
        public int PedidoItemId { get; set; }
        [Display(Name = "Mesa")]
        public int MesaId { get; set; }
        public int NumMesa { get; set; }
        [Display(Name = "Pedido Id")]
        public int PedidoId { get; set; }
        [Display(Name = "Observação")]
        public string Descricao { get; set; }
        [Display(Name = "Quant")]
        public int Quantidade { get; set; }
        [Display(Name = "Ajuste")]
        public decimal AjustePrco { get; set; }
        [Display(Name = "Data Pronto")]
        public DateTime? AServir { get; set; }
        [Display(Name = "Data Pedido")]
        public DateTime? EmPreparacao { get; set; }
        [Display(Name = "Data Servido")]
        public DateTime? Servido { get; set; }
        public MenuItemViewModel MenuItem { get; set; }
        
        public IList<PedidoItemViewModel> PedidosProntos { get; set; }

        public IList<PedidoItemViewModel> PedidosSolicitados(IList<PedidoItemViewModel> pedidos)
        {
            return pedidos;
        }

        public bool MarcarComoPronto
        {
            get
            {
                return (AServir.HasValue);
            }
            set
            {
                if (value)
                {
                    AServir = DateTime.Now;
                }
            }
        }
    }
}