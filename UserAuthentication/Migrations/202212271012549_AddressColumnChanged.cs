namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressColumnChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FullAddress", c => c.String());
            DropColumn("dbo.AspNetUsers", "City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            DropColumn("dbo.AspNetUsers", "FullAddress");
        }
    }
}
