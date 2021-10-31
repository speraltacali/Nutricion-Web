namespace NA.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Items : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemDetalle",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(),
                        PacienteId = c.Long(nullable: false),
                        ItemId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Item", t => t.ItemId)
                .ForeignKey("dbo.Paciente", t => t.PacienteId)
                .Index(t => t.PacienteId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nombre = c.String(),
                        Eliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemDetalle", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.ItemDetalle", "ItemId", "dbo.Item");
            DropIndex("dbo.ItemDetalle", new[] { "ItemId" });
            DropIndex("dbo.ItemDetalle", new[] { "PacienteId" });
            DropTable("dbo.Item");
            DropTable("dbo.ItemDetalle");
        }
    }
}
