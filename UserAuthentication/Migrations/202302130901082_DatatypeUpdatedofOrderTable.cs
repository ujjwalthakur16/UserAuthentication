namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatatypeUpdatedofOrderTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderDetails", "CGST", c => c.Double(nullable: false));
            AlterColumn("dbo.OrderDetails", "SGST", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderDetails", "SGST", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "CGST", c => c.Int(nullable: false));
        }
    }
}
