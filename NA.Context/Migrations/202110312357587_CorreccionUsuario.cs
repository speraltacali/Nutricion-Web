namespace NA.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorreccionUsuario : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuario", "Token", c => c.String());
            DropColumn("dbo.Usuario", "PerfilId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "PerfilId", c => c.Long(nullable: false));
            AlterColumn("dbo.Usuario", "Token", c => c.Int(nullable: false));
        }
    }
}
