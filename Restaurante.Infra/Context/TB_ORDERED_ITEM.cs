namespace Restaurante.Infra.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_ORDERED_ITEM
    {
        public int ID { get; set; }

        public int ID_MENU_ITEM { get; set; }

        public int ID_ORDERED { get; set; }

        public decimal? NU_PRICE_ADJUSTIMENT { get; set; }

        public DateTime? DT_TO_SERVE { get; set; }

        public DateTime? DT_IN_PREPARATION { get; set; }

        public DateTime? DT_SERVED { get; set; }

        [StringLength(200)]
        public string DS_DESCRIPTION { get; set; }

        public DateTime DT_SERVICE { get; set; }

        public virtual TB_MENU_ITEM TB_MENU_ITEM { get; set; }

        public virtual TB_ORDERED TB_ORDERED { get; set; }
    }
}
