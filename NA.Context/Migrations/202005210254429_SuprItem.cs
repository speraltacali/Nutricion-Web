namespace NA.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SuprItem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ejercicio", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.Enfermedad", "PacienteId", "dbo.Paciente");
            DropIndex("dbo.Ejercicio", new[] { "PacienteId" });
            DropIndex("dbo.Enfermedad", new[] { "PacienteId" });
            AddColumn("dbo.InformeAntropometrico", "Eliminado", c => c.Boolean(nullable: false));
            AddColumn("dbo.ContexturaCorporal", "Eliminado", c => c.Boolean(nullable: false));
            DropColumn("dbo.InformeAntropometrico", "Eliminar");
            DropTable("dbo.Ejercicio");
            DropTable("dbo.Enfermedad");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Enfermedad",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PacienteId = c.Long(nullable: false),
                        TieneEnfermedad = c.Boolean(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ejercicio",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PacienteId = c.Long(nullable: false),
                        RealizaEjercicio = c.Boolean(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.InformeAntropometrico", "Eliminar", c => c.Boolean(nullable: false));
            DropColumn("dbo.ContexturaCorporal", "Eliminado");
            DropColumn("dbo.InformeAntropometrico", "Eliminado");
            CreateIndex("dbo.Enfermedad", "PacienteId");
            CreateIndex("dbo.Ejercicio", "PacienteId");
            AddForeignKey("dbo.Enfermedad", "PacienteId", "dbo.Paciente", "Id");
            AddForeignKey("dbo.Ejercicio", "PacienteId", "dbo.Paciente", "Id");
        }
    }
}
