namespace Restaurante.Infra.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CafeContext : DbContext, ICafeContext
    {
        public CafeContext()
            : base("name=CafeContext")
        {
        }

        public virtual DbSet<TB_ACCESS> TB_ACCESS { get; set; }
        public virtual DbSet<TB_MENU_ITEM> TB_MENU_ITEM { get; set; }
        public virtual DbSet<TB_ORDERED> TB_ORDERED { get; set; }
        public virtual DbSet<TB_ORDERED_ITEM> TB_ORDERED_ITEM { get; set; }
        public virtual DbSet<TB_TAB_CLOSED> TB_TAB_CLOSED { get; set; }
        public virtual DbSet<TB_TAB_OPENED> TB_TAB_OPENED { get; set; }
        public virtual DbSet<TB_TODO> TB_TODO { get; set; }
        public virtual DbSet<TB_WAITSTAFF> TB_WAITSTAFF { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TB_ACCESS>()
                .Property(e => e.DS_EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ACCESS>()
                .Property(e => e.DS_PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ACCESS>()
                .Property(e => e.DS_PERFIL)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ACCESS>()
                .Property(e => e.DS_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ACCESS>()
                .Property(e => e.DS_LAST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_MENU_ITEM>()
                .Property(e => e.DS_DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<TB_MENU_ITEM>()
                .HasMany(e => e.TB_ORDERED_ITEM)
                .WithRequired(e => e.TB_MENU_ITEM)
                .HasForeignKey(e => e.ID_MENU_ITEM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TB_ORDERED>()
                .HasMany(e => e.TB_ORDERED_ITEM)
                .WithRequired(e => e.TB_ORDERED)
                .HasForeignKey(e => e.ID_ORDERED)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TB_ORDERED_ITEM>()
                .Property(e => e.DS_DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<TB_TAB_OPENED>()
                .HasMany(e => e.TB_ORDERED)
                .WithRequired(e => e.TB_TAB_OPENED)
                .HasForeignKey(e => e.ID_TAB_OPENED)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TB_TAB_OPENED>()
                .HasMany(e => e.TB_TODO)
                .WithRequired(e => e.TB_TAB_OPENED)
                .HasForeignKey(e => e.ID_TAB_OPENED)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TB_WAITSTAFF>()
                .Property(e => e.DS_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_WAITSTAFF>()
                .HasMany(e => e.TB_TAB_OPENED)
                .WithOptional(e => e.TB_WAITSTAFF)
                .HasForeignKey(e => e.ID_WAITER);
        }
    }
}
