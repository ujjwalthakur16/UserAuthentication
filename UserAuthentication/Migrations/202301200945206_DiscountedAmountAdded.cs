namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiscountedAmountAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Diccounted_MRP", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Products", "DiccountedAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "DiccountedAmount", c => c.String());
            DropColumn("dbo.Products", "Diccounted_MRP");
        }
    }
}
