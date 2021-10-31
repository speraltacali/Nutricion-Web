namespace NA.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TerminandoRelacionBase : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Circunferencia", "IAntropometricoId");
            CreateIndex("dbo.ContexturaCorporal", "IAntropometricoId");
            AddForeignKey("dbo.Circunferencia", "IAntropometricoId", "dbo.InformeAntropometrico", "Id");
            AddForeignKey("dbo.ContexturaCorporal", "IAntropometricoId", "dbo.InformeAntropometrico", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContexturaCorporal", "IAntropometricoId", "dbo.InformeAntropometrico");
            DropForeignKey("dbo.Circunferencia", "IAntropometricoId", "dbo.InformeAntropometrico");
            DropIndex("dbo.ContexturaCorporal", new[] { "IAntropometricoId" });
            DropIndex("dbo.Circunferencia", new[] { "IAntropometricoId" });
        }
    }
}
