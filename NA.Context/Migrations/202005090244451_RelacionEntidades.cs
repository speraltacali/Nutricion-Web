namespace NA.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelacionEntidades : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alimento",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PacienteId = c.Long(nullable: false),
                        GustoParticular = c.Boolean(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Circunferencia",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IAntropometricoId = c.Long(nullable: false),
                        Cintura = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cadera = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Muslo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pantorrilla = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BicepRelajado = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BicepContraido = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pecho = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cuello = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Eliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContexturaCorporal",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IAntropometricoId = c.Long(nullable: false),
                        Peso = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Altura = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dieta",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IAntropometricoId = c.Long(nullable: false),
                        CantidadComidas = c.Int(nullable: false),
                        Observaciones = c.String(),
                        Eliminado = c.Boolean(nullable: false),
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
                "dbo.InformeAntropometrico",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Observaciones = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        Eliminar = c.Boolean(nullable: false),
                        PacienteId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paciente", t => t.PacienteId)
                .Index(t => t.PacienteId);
            
            CreateTable(
                "dbo.Paciente",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Apellido = c.String(),
                        Nombre = c.String(),
                        Dni = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Sexo = c.Int(nullable: false),
                        Eliminar = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InformeAntropometrico", "PacienteId", "dbo.Paciente");
            DropIndex("dbo.InformeAntropometrico", new[] { "PacienteId" });
            DropTable("dbo.Paciente");
            DropTable("dbo.InformeAntropometrico");
            DropTable("dbo.Enfermedad");
            DropTable("dbo.Ejercicio");
            DropTable("dbo.Dieta");
            DropTable("dbo.ContexturaCorporal");
            DropTable("dbo.Circunferencia");
            DropTable("dbo.Alimento");
        }
    }
}
