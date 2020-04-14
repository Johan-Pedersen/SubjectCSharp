namespace HomeDepotWepApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        bookingId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        ToolId = c.Int(),
                        ResevationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.bookingId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Tools", t => t.ToolId)
                .Index(t => t.CustomerId)
                .Index(t => t.ToolId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Tools",
                c => new
                    {
                        ToolId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ToolId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "ToolId", "dbo.Tools");
            DropForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Bookings", new[] { "ToolId" });
            DropIndex("dbo.Bookings", new[] { "CustomerId" });
            DropTable("dbo.Tools");
            DropTable("dbo.Customers");
            DropTable("dbo.Bookings");
        }
    }
}
