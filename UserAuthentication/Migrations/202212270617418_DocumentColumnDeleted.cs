namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentColumnDeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Projects", "Document1");
            DropColumn("dbo.Projects", "Document2");
            DropColumn("dbo.Projects", "Document3");
            DropColumn("dbo.Projects", "Document4");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "Document4", c => c.String());
            AddColumn("dbo.Projects", "Document3", c => c.String());
            AddColumn("dbo.Projects", "Document2", c => c.String());
            AddColumn("dbo.Projects", "Document1", c => c.String());
        }
    }
}
