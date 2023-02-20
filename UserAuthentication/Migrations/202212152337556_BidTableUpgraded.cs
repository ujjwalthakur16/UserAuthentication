namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BidTableUpgraded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bids", "Skills", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bids", "Skills");
        }
    }
}
