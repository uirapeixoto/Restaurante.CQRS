﻿using Restaurante.Dominio.Pedido;
using System;
using System.Collections.Generic;

namespace Restaurante.Events
{
    public class DrinksOrdered
    {
        public Guid Id;
        public List<OrderedItem> Items;
    }
}
