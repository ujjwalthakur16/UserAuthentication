namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartTableUpdated : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Carts", new[] { "ProductId" });
            AlterColumn("dbo.Carts", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Carts", "ProductId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Carts", new[] { "ProductId" });
            AlterColumn("dbo.Carts", "ProductId", c => c.String());
            CreateIndex("dbo.Carts", "ProductId");
        }
    }
}
