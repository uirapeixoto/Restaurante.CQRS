using System;
using System.Collections.Generic;

namespace Restaurante.Events.Mesas
{
    public class FoodPrepared
    {
        public Guid Id;
        public List<int> MenuNumbers;
    }
}
