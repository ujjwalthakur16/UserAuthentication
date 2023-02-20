namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubscriptionTableUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subscriptions", "Prize", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subscriptions", "Prize");
        }
    }
}
