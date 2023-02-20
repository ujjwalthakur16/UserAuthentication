namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubscriptioncolumUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subscriptions", "PlansId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subscriptions", "PlansId");
        }
    }
}
