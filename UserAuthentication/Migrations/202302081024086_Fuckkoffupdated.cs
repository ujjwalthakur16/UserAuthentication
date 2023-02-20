namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fuckkoffupdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "Landmark", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "Landmark", c => c.String(nullable: false));
        }
    }
}
