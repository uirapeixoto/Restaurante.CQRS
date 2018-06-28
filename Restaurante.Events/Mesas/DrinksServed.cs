using System;
using System.Collections.Generic;

namespace Restaurante.Events.Mesas
{
    public class DrinksServed
    {
        public Guid Id;
        public List<int> MenuNumbers;
    }
}
