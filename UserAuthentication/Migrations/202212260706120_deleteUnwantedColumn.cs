namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteUnwantedColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Projects", "Bid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "Bid", c => c.String());
        }
    }
}
