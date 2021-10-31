namespace NA.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seguridad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        User = c.String(),
                        Password = c.String(),
                        Bloqueado = c.Boolean(nullable: false),
                        Token = c.Int(nullable: false),
                        Eliminado = c.Boolean(nullable: false),
                        PerfilId = c.Long(nullable: false),
                        PacienteId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paciente", t => t.PacienteId)
                .Index(t => t.PacienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "PacienteId", "dbo.Paciente");
            DropIndex("dbo.Usuario", new[] { "PacienteId" });
            DropTable("dbo.Usuario");
        }
    }
}
