namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "AddressId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "AddressId");
        }
    }
}
