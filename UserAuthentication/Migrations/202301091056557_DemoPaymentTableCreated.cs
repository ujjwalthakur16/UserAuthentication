namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DemoPaymentTableCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DemoPayments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        Amount = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        ProductInfo = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DemoPayments");
        }
    }
}
