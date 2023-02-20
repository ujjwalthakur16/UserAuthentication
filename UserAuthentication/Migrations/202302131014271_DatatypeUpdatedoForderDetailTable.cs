namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatatypeUpdatedoForderDetailTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "TotalPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Orders", "netAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.OrderDetails", "Prize", c => c.Double(nullable: false));
            AlterColumn("dbo.OrderDetails", "totalPrize", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderDetails", "totalPrize", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "Prize", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "netAmount", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "TotalPrice", c => c.Int(nullable: false));
        }
    }
}
