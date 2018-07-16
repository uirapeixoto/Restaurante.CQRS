﻿using System;
using System.Collections.Generic;
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
        public int Quantidade { get; set; }
        public DateTime? AServir { get; set; }
        public DateTime? EmPreparacao { get; set; }
        public DateTime? Servido { get; set; }

        public bool MarcarComoServido {
            get
            {
                return (Servido.HasValue)? true : false;
            }
            set
            {
                if (value)
                {
                    Servido = DateTime.Now;
                }
            }
        }

        [Display(Name = "Menu")]
        public IEnumerable<MenuItemViewModel> MenuItens { get; set; }

    }
}