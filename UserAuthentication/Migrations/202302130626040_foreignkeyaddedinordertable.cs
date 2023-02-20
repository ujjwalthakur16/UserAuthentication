namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkeyaddedinordertable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "AddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "AddressId");
            AddForeignKey("dbo.Orders", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Orders", new[] { "AddressId" });
            AlterColumn("dbo.Orders", "AddressId", c => c.String());
        }
    }
}
