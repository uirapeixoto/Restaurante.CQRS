namespace Restaurante.Infra.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_ORDERED_ITEM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_ORDERED_ITEM()
        {
            TB_ORDERED = new HashSet<TB_ORDERED>();
        }

        public int ID { get; set; }

        public int ID_MENU_ITEM { get; set; }


        public decimal? NU_PRICE_ADJUSTIMENT { get; set; }

        public bool? ST_TO_SERVE { get; set; }

        public bool? ST_IN_PREPARATION { get; set; }

        public bool? ST_SERVED { get; set; }

        [Required]
        [StringLength(200)]
        public string DS_DESCRIPTION { get; set; }

        public DateTime DT_SERVICE { get; set; }

        public virtual TB_MENU_ITEM TB_MENU_ITEM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_ORDERED> TB_ORDERED { get; set; }
    }
}
