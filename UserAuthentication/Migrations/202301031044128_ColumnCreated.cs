namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnCreated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "subscription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "subscription");
        }
    }
}
