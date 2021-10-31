namespace NA.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class documents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documento",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nombre = c.String(),
                        NombreReal = c.String(),
                        Doc = c.Binary(),
                        DietaId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dieta", t => t.DietaId)
                .Index(t => t.DietaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documento", "DietaId", "dbo.Dieta");
            DropIndex("dbo.Documento", new[] { "DietaId" });
            DropTable("dbo.Documento");
        }
    }
}
