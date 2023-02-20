namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartTableCreated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Carts", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Carts", "ProductId");
            AddForeignKey("dbo.Carts", "ProductId", "dbo.Products", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "ProductId" });
            AlterColumn("dbo.Carts", "ProductId", c => c.String());
        }
    }
}
