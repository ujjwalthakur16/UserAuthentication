namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bids", "Status", c => c.String());
            AddColumn("dbo.Projects", "BidAcceptedof", c => c.String());
            DropColumn("dbo.Projects", "Bidof");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "Bidof", c => c.String());
            DropColumn("dbo.Projects", "BidAcceptedof");
            DropColumn("dbo.Bids", "Status");
        }
    }
}
