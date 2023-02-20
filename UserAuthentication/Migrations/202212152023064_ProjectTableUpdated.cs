namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectTableUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Bid", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Bid");
        }
    }
}
