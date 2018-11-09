namespace AlmocoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MudancaUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "UsuarioEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "UsuarioEmail");
        }
    }
}
