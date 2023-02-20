namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fuckkoff : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "mobileNumber", c => c.String());
            AlterColumn("dbo.Addresses", "pinCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "pinCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Addresses", "mobileNumber", c => c.Int(nullable: false));
        }
    }
}
