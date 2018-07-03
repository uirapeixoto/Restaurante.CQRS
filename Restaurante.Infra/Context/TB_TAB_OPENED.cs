namespace Restaurante.Infra.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_TAB_OPENED
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_TAB_OPENED()
        {
            TB_ORDERED = new HashSet<TB_ORDERED>();
            TB_TODO = new HashSet<TB_TODO>();
        }

        public int ID { get; set; }

        public int? NU_TABLE { get; set; }

        public int? ID_WAITER { get; set; }

        public bool ST_ACTIVE { get; set; }

        public DateTime? DT_SERVICE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_ORDERED> TB_ORDERED { get; set; }

        public virtual TB_WAITSTAFF TB_WAITSTAFF { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_TODO> TB_TODO { get; set; }
    }
}
