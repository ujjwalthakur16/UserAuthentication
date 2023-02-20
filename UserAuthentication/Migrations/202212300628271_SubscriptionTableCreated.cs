namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubscriptionTableCreated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subscriptions", "SubscriptionType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subscriptions", "SubscriptionType");
        }
    }
}
