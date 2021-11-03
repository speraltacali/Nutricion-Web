namespace NA.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SolicitudCorreccion : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Nivel", t => t.NivelId)
                .Index(t => t.NivelId);
            
            AddColumn("dbo.Contenido", "Habilitado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contenido", "Eliminado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Solicitud", "NivelId", "dbo.Nivel");
            DropIndex("dbo.Solicitud", new[] { "NivelId" });
            DropColumn("dbo.Contenido", "Eliminado");
            DropColumn("dbo.Contenido", "Habilitado");
            DropTable("dbo.Solicitud");
        }
    }
}
