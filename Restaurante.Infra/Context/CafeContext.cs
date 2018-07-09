namespace Restaurante.Infra.Context
{
    using System.Data.Entity;

    public partial class CafeContext : DbContext, ICafeContext
    {
        public CafeContext()
           : base("name=CafeContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<TB_MENU_ITEM> TB_MENU_ITEM { get; set; }
        public virtual DbSet<TB_ORDERED> TB_ORDERED { get; set; }
        public virtual DbSet<TB_ORDERED_ITEM> TB_ORDERED_ITEM { get; set; }
        public virtual DbSet<TB_TAB_CLOSED> TB_TAB_CLOSED { get; set; }
        public virtual DbSet<TB_TAB_OPENED> TB_TAB_OPENED { get; set; }
        public virtual DbSet<TB_TODO> TB_TODO { get; set; }
        public virtual DbSet<TB_WAITSTAFF> TB_WAITSTAFF { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TB_MENU_ITEM>()
                .Property(e => e.DS_DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<TB_MENU_ITEM>()
                .HasMany(e => e.TB_ORDERED_ITEM)
                .WithRequired(e => e.TB_MENU_ITEM)
                .HasForeignKey(e => e.ID_MENU_ITEM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TB_ORDERED_ITEM>()
                .Property(e => e.DS_DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<TB_ORDERED_ITEM>()
                .HasMany(e => e.TB_ORDERED)
                .WithRequired(e => e.TB_ORDERED_ITEM)
                .HasForeignKey(e => e.ID_ORDERED_ITEM)
                .WillCascadeOnDelete(false);

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
