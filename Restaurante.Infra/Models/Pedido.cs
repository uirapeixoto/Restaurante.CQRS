using System;
using System.Collections.Generic;

namespace Restaurante.Infra.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public IEnumerable<Item> Itens { get; set; }
    }
}
