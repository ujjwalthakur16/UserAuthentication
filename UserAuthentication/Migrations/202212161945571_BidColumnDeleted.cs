namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BidColumnDeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Projects", "Bidby");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "Bidby", c => c.String());
        }
    }
}
