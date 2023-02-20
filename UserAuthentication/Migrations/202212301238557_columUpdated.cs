namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subscriptions", "Prize", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subscriptions", "Prize", c => c.Int(nullable: false));
        }
    }
}
