namespace Restaurante.Infra.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_TAB_CLOSED
    {
        public int ID { get; set; }

        public decimal? NU_AMOUNT_PAID { get; set; }

        public decimal? NU_ORDER_VALUE { get; set; }

        public decimal? NU_TIP_VALUE { get; set; }

        public DateTime? DT_SERVICE { get; set; }
    }
}
