namespace Restaurante.Infra.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_TODO
    {
        public int ID { get; set; }

        public int ID_TAB_OPENED { get; set; }

        public int ID_ORDERED { get; set; }

        public DateTime? DT_SERVICE { get; set; }

        public virtual TB_TAB_OPENED TB_TAB_OPENED { get; set; }
    }
}
