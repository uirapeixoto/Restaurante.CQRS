namespace Restaurante.Infra.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RestauranteContext : DbContext
    {
        public RestauranteContext()
            : base("name=RestauranteContext")
        {
        }

        public virtual DbSet<TB_TAB_OPENED> TB_TAB_OPENED { get; set; }
        public virtual DbSet<TB_WAITSTAFF> TB_WAITSTAFF { get; set; }
        public virtual DbSet<TB_MENU_ITEM> TB_MENU_ITEM { get; set; }
        public virtual DbSet<TB_ORDERED> TB_ORDERED { get; set; }
        public virtual DbSet<TB_ORDERED_ITEM> TB_ORDERED_ITEM { get; set; }
        public virtual DbSet<TB_TAB_CLOSED> TB_TAB_CLOSED { get; set; }
        public virtual DbSet<TB_TODO> TB_TODO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TB_WAITSTAFF>()
                .Property(e => e.DS_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_MENU_ITEM>()
                .Property(e => e.DS_DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ORDERED_ITEM>()
                .Property(e => e.DS_DESCRIPTION)
                .IsUnicode(false);
        }
    }
}
