using System;
using System.Data.Entity;

namespace Restaurante.Infra.Context
{
    public interface ICafeContext : IDisposable
    {
       
         DbSet<TB_MENU_ITEM> TB_MENU_ITEM { get; set; }
         DbSet<TB_ORDERED> TB_ORDERED { get; set; }
         DbSet<TB_ORDERED_ITEM> TB_ORDERED_ITEM { get; set; }
         DbSet<TB_TAB_CLOSED> TB_TAB_CLOSED { get; set; }
         DbSet<TB_TAB_OPENED> TB_TAB_OPENED { get; set; }
         DbSet<TB_TODO> TB_TODO { get; set; }
         DbSet<TB_WAITSTAFF> TB_WAITSTAFF { get; set; }


        int SaveChanges();
    }
}
