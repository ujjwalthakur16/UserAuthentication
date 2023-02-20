namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAll : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Categories", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Products", "DiscountFromDate", c => c.DateTime());
            AlterColumn("dbo.Products", "DiscountToDate", c => c.DateTime());
            AlterColumn("dbo.SubCategories", "CraetedDate", c => c.DateTime());
            AlterColumn("dbo.SubCategories", "ModifiedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SubCategories", "ModifiedDate", c => c.String());
            AlterColumn("dbo.SubCategories", "CraetedDate", c => c.String());
            AlterColumn("dbo.Products", "DiscountToDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "DiscountFromDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Categories", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Categories", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
