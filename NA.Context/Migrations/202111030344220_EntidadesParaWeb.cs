namespace NA.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntidadesParaWeb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contenido",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Titulo = c.String(),
                        SubTitulo = c.String(),
                        Cuerpo = c.String(),
                        Imagen = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Nivel",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Titulo = c.String(),
                        Descripcion = c.String(),
                        Imagen = c.Binary(),
                        Eliminado = c.Boolean(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LinkPago = c.String(),
                        PlanId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plan", t => t.PlanId)
                .Index(t => t.PlanId);
            
            CreateTable(
                "dbo.Plan",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Titulo = c.String(),
                        Descripcion = c.String(),
                        Eliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Nivel", "PlanId", "dbo.Plan");
            DropIndex("dbo.Nivel", new[] { "PlanId" });
            DropTable("dbo.Plan");
            DropTable("dbo.Nivel");
            DropTable("dbo.Contenido");
        }
    }
}
