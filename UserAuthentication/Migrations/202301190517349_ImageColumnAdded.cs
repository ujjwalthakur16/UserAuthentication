namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Picture", c => c.String());
            AddColumn("dbo.Products", "Picture", c => c.String());
            AddColumn("dbo.SubCategories", "Picture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubCategories", "Picture");
            DropColumn("dbo.Products", "Picture");
            DropColumn("dbo.Categories", "Picture");
        }
    }
}
