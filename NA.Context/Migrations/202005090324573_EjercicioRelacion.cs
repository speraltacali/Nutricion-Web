namespace NA.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EjercicioRelacion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Paciente", "Ejercicio_Id", "dbo.Ejercicio");
            DropIndex("dbo.Paciente", new[] { "Ejercicio_Id" });
            CreateIndex("dbo.Ejercicio", "PacienteId");
            AddForeignKey("dbo.Ejercicio", "PacienteId", "dbo.Paciente", "Id");
            DropColumn("dbo.Paciente", "Ejercicio_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Paciente", "Ejercicio_Id", c => c.Long());
            DropForeignKey("dbo.Ejercicio", "PacienteId", "dbo.Paciente");
            DropIndex("dbo.Ejercicio", new[] { "PacienteId" });
            CreateIndex("dbo.Paciente", "Ejercicio_Id");
            AddForeignKey("dbo.Paciente", "Ejercicio_Id", "dbo.Ejercicio", "Id");
        }
    }
}
