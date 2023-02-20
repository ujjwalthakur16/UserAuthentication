namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentColumnCreated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Document1", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Document1");
        }
    }
}
