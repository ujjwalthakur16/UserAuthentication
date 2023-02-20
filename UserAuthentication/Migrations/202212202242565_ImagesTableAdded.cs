namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagesTableAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bids", "Pictures", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bids", "Pictures");
        }
    }
}
