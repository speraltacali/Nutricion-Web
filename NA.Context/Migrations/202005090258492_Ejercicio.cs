namespace NA.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ejercicio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Paciente", "Ejercicio_Id", c => c.Long());
            CreateIndex("dbo.Paciente", "Ejercicio_Id");
            AddForeignKey("dbo.Paciente", "Ejercicio_Id", "dbo.Ejercicio", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Paciente", "Ejercicio_Id", "dbo.Ejercicio");
            DropIndex("dbo.Paciente", new[] { "Ejercicio_Id" });
            DropColumn("dbo.Paciente", "Ejercicio_Id");
        }
    }
}
