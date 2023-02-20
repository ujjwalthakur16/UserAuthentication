namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projectNameCreated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bids", "projectName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bids", "projectName");
        }
    }
}
