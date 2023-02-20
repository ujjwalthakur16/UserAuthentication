namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Priceof2AmountAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "PriceOf_2", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "PriceOf_2");
        }
    }
}
