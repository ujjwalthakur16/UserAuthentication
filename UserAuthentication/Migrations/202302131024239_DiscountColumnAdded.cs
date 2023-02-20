namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiscountColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "DiscountPercent", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "DiscountAmount", c => c.Double(nullable: false));
            DropColumn("dbo.Orders", "Discount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Discount", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "DiscountAmount");
            DropColumn("dbo.Orders", "DiscountPercent");
        }
    }
}
