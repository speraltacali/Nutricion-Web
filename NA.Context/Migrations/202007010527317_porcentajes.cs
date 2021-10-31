namespace NA.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class porcentajes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InformeAntropometrico", "PorcentajeGrasa", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.InformeAntropometrico", "KilosGrasa", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.InformeAntropometrico", "KilosMusculo", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InformeAntropometrico", "KilosMusculo");
            DropColumn("dbo.InformeAntropometrico", "KilosGrasa");
            DropColumn("dbo.InformeAntropometrico", "PorcentajeGrasa");
        }
    }
}
