namespace Restaurante.Infra.Migrations
{
    using Restaurante.Infra.Context;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Restaurante.Infra.Context.CafeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Restaurante.Infra.Context.CafeContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.TB_WAITSTAFF.AddOrUpdate(x => x.ID,
                new TB_WAITSTAFF() { ID = 1, DS_NAME = "Jack", DT_CREATED = DateTime.Now },
                new TB_WAITSTAFF() { ID = 2, DS_NAME = "Lena" , DT_CREATED = DateTime.Now },
                new TB_WAITSTAFF() { ID = 3, DS_NAME = "Pedro", DT_CREATED = DateTime.Now },
                new TB_WAITSTAFF() { ID = 4, DS_NAME = "Anastasia", DT_CREATED = DateTime.Now }
            );

            context.TB_MENU_ITEM.AddOrUpdate(x => x.ID,
                new TB_MENU_ITEM() { ID = 1, NU_MENU_ITEM = 1, DS_DESCRIPTION = "Heineken", NU_PRICE = (decimal)6.9, ST_ACTIVE = true, ST_IS_DRINK = true, DT_CREATED = DateTime.Now, TB_ORDERED_ITEM = null },
                new TB_MENU_ITEM() { ID = 2, NU_MENU_ITEM = 2, DS_DESCRIPTION = "Budweiser", NU_PRICE = (decimal)6.9, ST_ACTIVE = true, ST_IS_DRINK = true, DT_CREATED = DateTime.Now, TB_ORDERED_ITEM = null },
                new TB_MENU_ITEM() { ID = 3, NU_MENU_ITEM = 3, DS_DESCRIPTION = "Suco Natural", NU_PRICE = (decimal)4.5, ST_ACTIVE = true, ST_IS_DRINK = true, DT_CREATED = DateTime.Now, TB_ORDERED_ITEM = null },
                new TB_MENU_ITEM() { ID = 4, NU_MENU_ITEM = 4, DS_DESCRIPTION = "Suco Polpa", NU_PRICE = (decimal)4.0, ST_ACTIVE = true, ST_IS_DRINK = true, DT_CREATED = DateTime.Now, TB_ORDERED_ITEM = null },
                new TB_MENU_ITEM() { ID = 5, NU_MENU_ITEM = 5, DS_DESCRIPTION = "Suco Cremoso", NU_PRICE = (decimal)5.5, ST_ACTIVE = true, ST_IS_DRINK = true, DT_CREATED = DateTime.Now, TB_ORDERED_ITEM = null },
                new TB_MENU_ITEM() { ID = 6, NU_MENU_ITEM = 6, DS_DESCRIPTION = "Café Expresso", NU_PRICE = (decimal)4.0, ST_ACTIVE = true, ST_IS_DRINK = true, DT_CREATED = DateTime.Now, TB_ORDERED_ITEM = null },
                new TB_MENU_ITEM() { ID = 7, NU_MENU_ITEM = 7, DS_DESCRIPTION = "Porção de Pastel (12)", NU_PRICE = (decimal)6.9, ST_ACTIVE = true, ST_IS_DRINK = false, DT_CREATED = DateTime.Now, TB_ORDERED_ITEM = null },
                new TB_MENU_ITEM() { ID = 8, NU_MENU_ITEM = 8, DS_DESCRIPTION = "Porção Batata Frita Média", NU_PRICE = (decimal)6.9, ST_ACTIVE = true, ST_IS_DRINK = false, DT_CREATED = DateTime.Now, TB_ORDERED_ITEM = null },
                new TB_MENU_ITEM() { ID = 9, NU_MENU_ITEM = 9, DS_DESCRIPTION = "Porção Batata Frita Grande", NU_PRICE = (decimal)6.9, ST_ACTIVE = true, ST_IS_DRINK = false, DT_CREATED = DateTime.Now, TB_ORDERED_ITEM = null }
            );
            base.Seed(context);
        }
    }
}
