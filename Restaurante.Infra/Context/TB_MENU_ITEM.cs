namespace Restaurante.Infra.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_MENU_ITEM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_MENU_ITEM()
        {
            TB_ORDERED_ITEM = new HashSet<TB_ORDERED_ITEM>();
        }

        public int ID { get; set; }

        public int NU_MENU_ITEM { get; set; }

        [Required]
        [StringLength(200)]
        public string DS_DESCRIPTION { get; set; }

        public decimal NU_PRICE { get; set; }

        public bool ST_IS_DRINK { get; set; }

        public bool ST_ACTIVE { get; set; }

        public DateTime DT_CREATED { get; set; }

        public DateTime? DT_UPDATED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_ORDERED_ITEM> TB_ORDERED_ITEM { get; set; }
    }
}
