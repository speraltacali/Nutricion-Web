namespace NA.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorreccionesEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InformeAntropometrico", "Numero", c => c.Int(nullable: false));
            DropColumn("dbo.Dieta", "Observaciones");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dieta", "Observaciones", c => c.String());
            DropColumn("dbo.InformeAntropometrico", "Numero");
        }
    }
}
