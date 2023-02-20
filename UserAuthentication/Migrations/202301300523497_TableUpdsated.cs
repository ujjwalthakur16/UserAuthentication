namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableUpdsated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "ItemTotal", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "ItemTotal");
        }
    }
}
