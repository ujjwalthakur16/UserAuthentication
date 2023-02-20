namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusColumnCreated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plans", "status", c => c.String());
            AddColumn("dbo.Subscriptions", "status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subscriptions", "status");
            DropColumn("dbo.Plans", "status");
        }
    }
}
