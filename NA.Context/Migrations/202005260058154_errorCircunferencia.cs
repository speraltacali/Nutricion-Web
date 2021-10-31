namespace NA.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class errorCircunferencia : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Circunferencia", "IAntropometricoId", "dbo.InformeAntropometrico");
            DropIndex("dbo.Circunferencia", new[] { "IAntropometricoId" });
            DropColumn("dbo.Circunferencia", "IAntropometricoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Circunferencia", "IAntropometricoId", c => c.Long(nullable: false));
            CreateIndex("dbo.Circunferencia", "IAntropometricoId");
            AddForeignKey("dbo.Circunferencia", "IAntropometricoId", "dbo.InformeAntropometrico", "Id");
        }
    }
}
