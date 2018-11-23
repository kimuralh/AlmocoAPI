namespace AlmocoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MudancaIntGrupo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsuarioGrupoes", "Grupo_GrupoId", "dbo.Grupoes");
            DropForeignKey("dbo.Restaurantes", "Grupo_GrupoId", "dbo.Grupoes");
            DropForeignKey("dbo.Enquetes", "Grupo_GrupoId", "dbo.Grupoes");
            DropIndex("dbo.Enquetes", new[] { "Grupo_GrupoId" });
            DropIndex("dbo.Restaurantes", new[] { "Grupo_GrupoId" });
            DropIndex("dbo.UsuarioGrupoes", new[] { "Grupo_GrupoId" });
            DropPrimaryKey("dbo.Grupoes");
            DropPrimaryKey("dbo.UsuarioGrupoes");
            AlterColumn("dbo.Enquetes", "Grupo_GrupoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Grupoes", "GrupoId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Restaurantes", "Grupo_GrupoId", c => c.Int());
            AlterColumn("dbo.UsuarioGrupoes", "Grupo_GrupoId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Grupoes", "GrupoId");
            AddPrimaryKey("dbo.UsuarioGrupoes", new[] { "Usuario_UsuarioId", "Grupo_GrupoId" });
            CreateIndex("dbo.Enquetes", "Grupo_GrupoId");
            CreateIndex("dbo.Restaurantes", "Grupo_GrupoId");
            CreateIndex("dbo.UsuarioGrupoes", "Grupo_GrupoId");
            AddForeignKey("dbo.UsuarioGrupoes", "Grupo_GrupoId", "dbo.Grupoes", "GrupoId", cascadeDelete: true);
            AddForeignKey("dbo.Restaurantes", "Grupo_GrupoId", "dbo.Grupoes", "GrupoId");
            AddForeignKey("dbo.Enquetes", "Grupo_GrupoId", "dbo.Grupoes", "GrupoId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enquetes", "Grupo_GrupoId", "dbo.Grupoes");
            DropForeignKey("dbo.Restaurantes", "Grupo_GrupoId", "dbo.Grupoes");
            DropForeignKey("dbo.UsuarioGrupoes", "Grupo_GrupoId", "dbo.Grupoes");
            DropIndex("dbo.UsuarioGrupoes", new[] { "Grupo_GrupoId" });
            DropIndex("dbo.Restaurantes", new[] { "Grupo_GrupoId" });
            DropIndex("dbo.Enquetes", new[] { "Grupo_GrupoId" });
            DropPrimaryKey("dbo.UsuarioGrupoes");
            DropPrimaryKey("dbo.Grupoes");
            AlterColumn("dbo.UsuarioGrupoes", "Grupo_GrupoId", c => c.Long(nullable: false));
            AlterColumn("dbo.Restaurantes", "Grupo_GrupoId", c => c.Long());
            AlterColumn("dbo.Grupoes", "GrupoId", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Enquetes", "Grupo_GrupoId", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.UsuarioGrupoes", new[] { "Usuario_UsuarioId", "Grupo_GrupoId" });
            AddPrimaryKey("dbo.Grupoes", "GrupoId");
            CreateIndex("dbo.UsuarioGrupoes", "Grupo_GrupoId");
            CreateIndex("dbo.Restaurantes", "Grupo_GrupoId");
            CreateIndex("dbo.Enquetes", "Grupo_GrupoId");
            AddForeignKey("dbo.Enquetes", "Grupo_GrupoId", "dbo.Grupoes", "GrupoId", cascadeDelete: true);
            AddForeignKey("dbo.Restaurantes", "Grupo_GrupoId", "dbo.Grupoes", "GrupoId");
            AddForeignKey("dbo.UsuarioGrupoes", "Grupo_GrupoId", "dbo.Grupoes", "GrupoId", cascadeDelete: true);
        }
    }
}
