namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BidofColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Bidof", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Bidof");
        }
    }
}
