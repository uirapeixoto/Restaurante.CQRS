using System;

namespace Restaurante.Events.Mesas
{
    public class TabClosed
    {
        public Guid Id;
        public decimal AmountPaid;
        public decimal OrderValue;
        public decimal TipValue;
    }
}
