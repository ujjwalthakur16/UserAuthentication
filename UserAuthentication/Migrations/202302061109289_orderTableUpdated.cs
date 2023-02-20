namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderTableUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "orderStatus", c => c.String());
            AddColumn("dbo.Orders", "paymentStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "paymentStatus");
            DropColumn("dbo.Orders", "orderStatus");
        }
    }
}
