namespace AlmocoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MudancaNxNRestauranteEnqueteFinal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enquetes",
                c => new
                    {
                        EnqueteId = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        Grupo_GrupoId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.EnqueteId)
                .ForeignKey("dbo.Grupoes", t => t.Grupo_GrupoId, cascadeDelete: true)
                .Index(t => t.Grupo_GrupoId);
            
            CreateTable(
                "dbo.Grupoes",
                c => new
                    {
                        GrupoId = c.Long(nullable: false, identity: true),
                        GrupoNome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GrupoId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        UsuarioCpf = c.Long(nullable: false),
                        UsuarioNome = c.String(nullable: false),
                        UsuarioSaldo = c.Double(nullable: false),
                        UsuarioEmail = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Votoes",
                c => new
                    {
                        VotoId = c.Int(nullable: false, identity: true),
                        Restaurante_RestauranteId = c.Int(nullable: false),
                        Usuario_UsuarioId = c.Int(nullable: false),
                        Enquete_EnqueteId = c.Int(),
                    })
                .PrimaryKey(t => t.VotoId)
                .ForeignKey("dbo.Restaurantes", t => t.Restaurante_RestauranteId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_UsuarioId, cascadeDelete: true)
                .ForeignKey("dbo.Enquetes", t => t.Enquete_EnqueteId)
                .Index(t => t.Restaurante_RestauranteId)
                .Index(t => t.Usuario_UsuarioId)
                .Index(t => t.Enquete_EnqueteId);
            
            CreateTable(
                "dbo.Restaurantes",
                c => new
                    {
                        RestauranteId = c.Int(nullable: false, identity: true),
                        RestauranteNome = c.String(nullable: false),
                        VezesFrequentado = c.Int(nullable: false),
                        PrecoTotal = c.Double(nullable: false),
                        PrecoMedio = c.Double(nullable: false),
                        Grupo_GrupoId = c.Long(),
                    })
                .PrimaryKey(t => t.RestauranteId)
                .ForeignKey("dbo.Grupoes", t => t.Grupo_GrupoId)
                .Index(t => t.Grupo_GrupoId);
            
            CreateTable(
                "dbo.UsuarioGrupoes",
                c => new
                    {
                        Usuario_UsuarioId = c.Int(nullable: false),
                        Grupo_GrupoId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Usuario_UsuarioId, t.Grupo_GrupoId })
                .ForeignKey("dbo.Usuarios", t => t.Usuario_UsuarioId, cascadeDelete: true)
                .ForeignKey("dbo.Grupoes", t => t.Grupo_GrupoId, cascadeDelete: true)
                .Index(t => t.Usuario_UsuarioId)
                .Index(t => t.Grupo_GrupoId);
            
            CreateTable(
                "dbo.RestauranteEnquetes",
                c => new
                    {
                        Restaurante_RestauranteId = c.Int(nullable: false),
                        Enquete_EnqueteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Restaurante_RestauranteId, t.Enquete_EnqueteId })
                .ForeignKey("dbo.Restaurantes", t => t.Restaurante_RestauranteId, cascadeDelete: true)
                .ForeignKey("dbo.Enquetes", t => t.Enquete_EnqueteId, cascadeDelete: true)
                .Index(t => t.Restaurante_RestauranteId)
                .Index(t => t.Enquete_EnqueteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votoes", "Enquete_EnqueteId", "dbo.Enquetes");
            DropForeignKey("dbo.Enquetes", "Grupo_GrupoId", "dbo.Grupoes");
            DropForeignKey("dbo.Votoes", "Usuario_UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Votoes", "Restaurante_RestauranteId", "dbo.Restaurantes");
            DropForeignKey("dbo.Restaurantes", "Grupo_GrupoId", "dbo.Grupoes");
            DropForeignKey("dbo.RestauranteEnquetes", "Enquete_EnqueteId", "dbo.Enquetes");
            DropForeignKey("dbo.RestauranteEnquetes", "Restaurante_RestauranteId", "dbo.Restaurantes");
            DropForeignKey("dbo.UsuarioGrupoes", "Grupo_GrupoId", "dbo.Grupoes");
            DropForeignKey("dbo.UsuarioGrupoes", "Usuario_UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.RestauranteEnquetes", new[] { "Enquete_EnqueteId" });
            DropIndex("dbo.RestauranteEnquetes", new[] { "Restaurante_RestauranteId" });
            DropIndex("dbo.UsuarioGrupoes", new[] { "Grupo_GrupoId" });
            DropIndex("dbo.UsuarioGrupoes", new[] { "Usuario_UsuarioId" });
            DropIndex("dbo.Restaurantes", new[] { "Grupo_GrupoId" });
            DropIndex("dbo.Votoes", new[] { "Enquete_EnqueteId" });
            DropIndex("dbo.Votoes", new[] { "Usuario_UsuarioId" });
            DropIndex("dbo.Votoes", new[] { "Restaurante_RestauranteId" });
            DropIndex("dbo.Enquetes", new[] { "Grupo_GrupoId" });
            DropTable("dbo.RestauranteEnquetes");
            DropTable("dbo.UsuarioGrupoes");
            DropTable("dbo.Restaurantes");
            DropTable("dbo.Votoes");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Grupoes");
            DropTable("dbo.Enquetes");
        }
    }
}
