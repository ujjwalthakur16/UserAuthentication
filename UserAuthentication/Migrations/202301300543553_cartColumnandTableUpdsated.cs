namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cartColumnandTableUpdsated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "grandTotal", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "grandTotal");
        }
    }
}
