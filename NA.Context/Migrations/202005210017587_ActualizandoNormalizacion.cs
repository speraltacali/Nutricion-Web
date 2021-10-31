namespace NA.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizandoNormalizacion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InformeCircunferencia",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AntropometricoId = c.Long(nullable: false),
                        CircunferenciaId = c.Long(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Circunferencia", t => t.CircunferenciaId)
                .ForeignKey("dbo.InformeAntropometrico", t => t.AntropometricoId)
                .Index(t => t.AntropometricoId)
                .Index(t => t.CircunferenciaId);
            
            AddColumn("dbo.Circunferencia", "Nombre", c => c.String());
            AddColumn("dbo.InformeAntropometrico", "Observacion", c => c.String());
            DropColumn("dbo.Circunferencia", "Cintura");
            DropColumn("dbo.Circunferencia", "Cadera");
            DropColumn("dbo.Circunferencia", "Muslo");
            DropColumn("dbo.Circunferencia", "Pantorrilla");
            DropColumn("dbo.Circunferencia", "BicepRelajado");
            DropColumn("dbo.Circunferencia", "BicepContraido");
            DropColumn("dbo.Circunferencia", "Pecho");
            DropColumn("dbo.Circunferencia", "Cuello");
            DropColumn("dbo.InformeAntropometrico", "Observaciones");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InformeAntropometrico", "Observaciones", c => c.String());
            AddColumn("dbo.Circunferencia", "Cuello", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Circunferencia", "Pecho", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Circunferencia", "BicepContraido", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Circunferencia", "BicepRelajado", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Circunferencia", "Pantorrilla", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Circunferencia", "Muslo", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Circunferencia", "Cadera", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Circunferencia", "Cintura", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.InformeCircunferencia", "AntropometricoId", "dbo.InformeAntropometrico");
            DropForeignKey("dbo.InformeCircunferencia", "CircunferenciaId", "dbo.Circunferencia");
            DropIndex("dbo.InformeCircunferencia", new[] { "CircunferenciaId" });
            DropIndex("dbo.InformeCircunferencia", new[] { "AntropometricoId" });
            DropColumn("dbo.InformeAntropometrico", "Observacion");
            DropColumn("dbo.Circunferencia", "Nombre");
            DropTable("dbo.InformeCircunferencia");
        }
    }
}
