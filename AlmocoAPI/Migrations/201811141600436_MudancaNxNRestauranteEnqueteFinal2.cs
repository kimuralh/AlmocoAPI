namespace AlmocoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MudancaNxNRestauranteEnqueteFinal2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Votoes", "Enquete_EnqueteId", "dbo.Enquetes");
            DropIndex("dbo.Votoes", new[] { "Enquete_EnqueteId" });
            AlterColumn("dbo.Votoes", "Enquete_EnqueteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Votoes", "Enquete_EnqueteId");
            AddForeignKey("dbo.Votoes", "Enquete_EnqueteId", "dbo.Enquetes", "EnqueteId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votoes", "Enquete_EnqueteId", "dbo.Enquetes");
            DropIndex("dbo.Votoes", new[] { "Enquete_EnqueteId" });
            AlterColumn("dbo.Votoes", "Enquete_EnqueteId", c => c.Int());
            CreateIndex("dbo.Votoes", "Enquete_EnqueteId");
            AddForeignKey("dbo.Votoes", "Enquete_EnqueteId", "dbo.Enquetes", "EnqueteId");
        }
    }
}
