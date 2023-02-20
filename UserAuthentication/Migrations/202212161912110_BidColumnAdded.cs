namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BidColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Bidby", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Bidby");
        }
    }
}
