namespace Restaurante.Infra.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_ACCESS
    {
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string DS_EMAIL { get; set; }

        [Required]
        [StringLength(200)]
        public string DS_PASSWORD { get; set; }

        public bool ST_ACTIVE { get; set; }

        [Required]
        [StringLength(200)]
        public string DS_PERFIL { get; set; }

        [Required]
        [StringLength(200)]
        public string DS_NAME { get; set; }

        [Required]
        [StringLength(200)]
        public string DS_LAST_NAME { get; set; }

        public DateTime? DT_ACCESS { get; set; }
    }
}
