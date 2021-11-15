namespace NA.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorreccionModelo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ObraSocialPaciente", "ObraSocialId", "dbo.ObraSocial");
            DropForeignKey("dbo.ObraSocialPaciente", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.Solicitud", "NivelId", "dbo.Nivel");
            DropIndex("dbo.ObraSocialPaciente", new[] { "PacienteId" });
            DropIndex("dbo.ObraSocialPaciente", new[] { "ObraSocialId" });
            DropIndex("dbo.Solicitud", new[] { "NivelId" });
            DropTable("dbo.ObraSocialPaciente");
            DropTable("dbo.ObraSocial");
            DropTable("dbo.Contenido");
            DropTable("dbo.Solicitud");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Solicitud",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Correo = c.String(),
                        Telefono = c.String(),
                        Peso = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Altura = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Edad = c.Int(nullable: false),
                        Objetivo = c.String(),
                        Alimentacion = c.String(),
                        Enfermedad = c.String(),
                        Suplemento = c.String(),
                        Gustos = c.String(),
                        ActFisica = c.String(),
                        Comentariio = c.String(),
                        Comprobante = c.Binary(),
                        Realizado = c.Boolean(nullable: false),
                        NivelId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contenido",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Titulo = c.String(),
                        SubTitulo = c.String(),
                        Cuerpo = c.String(),
                        Imagen = c.Binary(),
                        Habilitado = c.Boolean(nullable: false),
                        Eliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ObraSocial",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nombre = c.String(),
                        Eliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ObraSocialPaciente",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PacienteId = c.Long(nullable: false),
                        ObraSocialId = c.Long(nullable: false),
                        NumeroAfiliado = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Solicitud", "NivelId");
            CreateIndex("dbo.ObraSocialPaciente", "ObraSocialId");
            CreateIndex("dbo.ObraSocialPaciente", "PacienteId");
            AddForeignKey("dbo.Solicitud", "NivelId", "dbo.Nivel", "Id");
            AddForeignKey("dbo.ObraSocialPaciente", "PacienteId", "dbo.Paciente", "Id");
            AddForeignKey("dbo.ObraSocialPaciente", "ObraSocialId", "dbo.ObraSocial", "Id");
        }
    }
}
