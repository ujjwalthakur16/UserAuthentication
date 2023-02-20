namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bids", "Picture", c => c.String());
            AddColumn("dbo.Projects", "Picture", c => c.String());
            DropColumn("dbo.Bids", "Pictures");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bids", "Pictures", c => c.String());
            DropColumn("dbo.Projects", "Picture");
            DropColumn("dbo.Bids", "Picture");
        }
    }
}
