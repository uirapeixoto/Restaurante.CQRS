using Restaurante.Dominio.Pedido;
using System;
using System.Collections.Generic;

namespace Restaurante.Events
{
    public class FoodOrdered
    {
        public Guid Id;
        public List<OrderedItem> Items;
    }
}
