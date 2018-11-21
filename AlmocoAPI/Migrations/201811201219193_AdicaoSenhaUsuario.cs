namespace AlmocoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicaoSenhaUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "UsuarioSenha", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "UsuarioSenha");
        }
    }
}
