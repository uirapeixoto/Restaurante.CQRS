namespace Restaurante.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class estruturaPedidos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_MENU_ITEM",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NU_MENU_ITEM = c.Int(nullable: false),
                        DS_DESCRIPTION = c.String(nullable: false, maxLength: 200, unicode: false),
                        NU_PRICE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ST_IS_DRINK = c.Boolean(nullable: false),
                        ST_ACTIVE = c.Boolean(nullable: false),
                        DT_CREATED = c.DateTime(nullable: false),
                        DT_UPDATED = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TB_ORDERED_ITEM",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ID_MENU_ITEM = c.Int(nullable: false),
                        NU_PRICE_ADJUSTIMENT = c.Decimal(precision: 18, scale: 2),
                        ST_TO_SERVE = c.Boolean(),
                        ST_IN_PREPARATION = c.Boolean(),
                        ST_SERVED = c.Boolean(),
                        DS_DESCRIPTION = c.String(nullable: false, maxLength: 200, unicode: false),
                        DT_SERVICE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TB_MENU_ITEM", t => t.ID_MENU_ITEM)
                .Index(t => t.ID_MENU_ITEM);
            
            CreateTable(
                "dbo.TB_ORDERED",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ID_TAB_OPENED = c.Int(nullable: false),
                        ID_ORDERED_ITEM = c.Int(nullable: false),
                        DT_SERVICE = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TB_TAB_OPENED", t => t.ID_TAB_OPENED)
                .ForeignKey("dbo.TB_ORDERED_ITEM", t => t.ID_ORDERED_ITEM)
                .Index(t => t.ID_TAB_OPENED)
                .Index(t => t.ID_ORDERED_ITEM);
            
            CreateTable(
                "dbo.TB_TAB_OPENED",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NU_TABLE = c.Int(),
                        ID_WAITER = c.Int(),
                        ST_ACTIVE = c.Boolean(nullable: false),
                        DT_SERVICE = c.DateTime(),
                        ST_UNIQUE_IDENTIFIER = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TB_WAITSTAFF", t => t.ID_WAITER)
                .Index(t => t.ID_WAITER);
            
            CreateTable(
                "dbo.TB_TODO",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ID_TAB_OPENED = c.Int(nullable: false),
                        ID_ORDERED = c.Int(nullable: false),
                        DT_SERVICE = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TB_TAB_OPENED", t => t.ID_TAB_OPENED)
                .Index(t => t.ID_TAB_OPENED);
            
            CreateTable(
                "dbo.TB_WAITSTAFF",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DS_NAME = c.String(nullable: false, maxLength: 200, unicode: false),
                        DT_CREATED = c.DateTime(nullable: false),
                        DT_UPDATED = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TB_TAB_CLOSED",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NU_AMOUNT_PAID = c.Decimal(precision: 18, scale: 2),
                        NU_ORDER_VALUE = c.Decimal(precision: 18, scale: 2),
                        NU_TIP_VALUE = c.Decimal(precision: 18, scale: 2),
                        DT_SERVICE = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_ORDERED_ITEM", "ID_MENU_ITEM", "dbo.TB_MENU_ITEM");
            DropForeignKey("dbo.TB_ORDERED", "ID_ORDERED_ITEM", "dbo.TB_ORDERED_ITEM");
            DropForeignKey("dbo.TB_TAB_OPENED", "ID_WAITER", "dbo.TB_WAITSTAFF");
            DropForeignKey("dbo.TB_TODO", "ID_TAB_OPENED", "dbo.TB_TAB_OPENED");
            DropForeignKey("dbo.TB_ORDERED", "ID_TAB_OPENED", "dbo.TB_TAB_OPENED");
            DropIndex("dbo.TB_TODO", new[] { "ID_TAB_OPENED" });
            DropIndex("dbo.TB_TAB_OPENED", new[] { "ID_WAITER" });
            DropIndex("dbo.TB_ORDERED", new[] { "ID_ORDERED_ITEM" });
            DropIndex("dbo.TB_ORDERED", new[] { "ID_TAB_OPENED" });
            DropIndex("dbo.TB_ORDERED_ITEM", new[] { "ID_MENU_ITEM" });
            DropTable("dbo.TB_TAB_CLOSED");
            DropTable("dbo.TB_WAITSTAFF");
            DropTable("dbo.TB_TODO");
            DropTable("dbo.TB_TAB_OPENED");
            DropTable("dbo.TB_ORDERED");
            DropTable("dbo.TB_ORDERED_ITEM");
            DropTable("dbo.TB_MENU_ITEM");
        }
    }
}
