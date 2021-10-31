namespace NA.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuitandoEntidades : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dieta", "TipoPlan", c => c.Int(nullable: false));
            AddColumn("dbo.Dieta", "Calorias", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Dieta", "IAntropometricoId");
            AddForeignKey("dbo.Dieta", "IAntropometricoId", "dbo.InformeAntropometrico", "Id");
            DropTable("dbo.Alimento");
        }
        
        public override void Down()
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
            
            DropForeignKey("dbo.Dieta", "IAntropometricoId", "dbo.InformeAntropometrico");
            DropIndex("dbo.Dieta", new[] { "IAntropometricoId" });
            DropColumn("dbo.Dieta", "Calorias");
            DropColumn("dbo.Dieta", "TipoPlan");
        }
    }
}
