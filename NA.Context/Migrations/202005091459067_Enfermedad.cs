namespace NA.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Enfermedad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Paciente", "Eliminado", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Enfermedad", "PacienteId");
            AddForeignKey("dbo.Enfermedad", "PacienteId", "dbo.Paciente", "Id");
            DropColumn("dbo.Paciente", "Eliminar");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Paciente", "Eliminar", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Enfermedad", "PacienteId", "dbo.Paciente");
            DropIndex("dbo.Enfermedad", new[] { "PacienteId" });
            DropColumn("dbo.Paciente", "Eliminado");
        }
    }
}
