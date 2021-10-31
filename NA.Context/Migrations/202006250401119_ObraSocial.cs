namespace NA.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ObraSocial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ObraSocialPaciente",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PacienteId = c.Long(nullable: false),
                        ObraSocialId = c.Long(nullable: false),
                        NumeroAfiliado = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ObraSocial", t => t.ObraSocialId)
                .ForeignKey("dbo.Paciente", t => t.PacienteId)
                .Index(t => t.PacienteId)
                .Index(t => t.ObraSocialId);
            
            CreateTable(
                "dbo.ObraSocial",
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
            DropForeignKey("dbo.ObraSocialPaciente", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.ObraSocialPaciente", "ObraSocialId", "dbo.ObraSocial");
            DropIndex("dbo.ObraSocialPaciente", new[] { "ObraSocialId" });
            DropIndex("dbo.ObraSocialPaciente", new[] { "PacienteId" });
            DropTable("dbo.ObraSocial");
            DropTable("dbo.ObraSocialPaciente");
        }
    }
}
