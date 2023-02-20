namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectDocumentCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectDocuments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.String(),
                        Document = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProjectDocuments");
        }
    }
}
