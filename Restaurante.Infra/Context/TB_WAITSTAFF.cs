namespace Restaurante.Infra.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_WAITSTAFF
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_WAITSTAFF()
        {
            TB_TAB_OPENED = new HashSet<TB_TAB_OPENED>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string DS_NAME { get; set; }

        public DateTime DT_CREATED { get; set; }

        public DateTime? DT_UPDATED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_TAB_OPENED> TB_TAB_OPENED { get; set; }
    }
}
