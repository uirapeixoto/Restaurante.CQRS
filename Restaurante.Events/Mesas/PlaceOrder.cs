using Restaurante.Dominio;
using System;
using System.Collections.Generic;

namespace Restaurante.Events
{
    public class PlaceOrder
    {
        public Guid Id;
        public List<OrderedItem> Items;
    }
}
