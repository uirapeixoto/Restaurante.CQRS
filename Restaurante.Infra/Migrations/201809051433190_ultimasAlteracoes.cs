namespace Restaurante.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ultimasAlteracoes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_ACCESS",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DS_EMAIL = c.String(nullable: false, maxLength: 200, unicode: false),
                        DS_PASSWORD = c.String(nullable: false, maxLength: 200, unicode: false),
                        ST_ACTIVE = c.Boolean(nullable: false),
                        DS_PERFIL = c.String(nullable: false, maxLength: 200, unicode: false),
                        DS_NAME = c.String(nullable: false, maxLength: 200, unicode: false),
                        DS_LAST_NAME = c.String(nullable: false, maxLength: 200, unicode: false),
                        DT_ACCESS = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TB_ACCESS");
        }
    }
}
