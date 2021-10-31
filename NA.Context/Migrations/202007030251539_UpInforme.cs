namespace NA.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpInforme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InformeAntropometrico", "PorcentajeMusculo", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InformeAntropometrico", "PorcentajeMusculo");
        }
    }
}
