namespace HomeDepotWepApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "FromDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Bookings", "ToDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Bookings", "ResevationDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "ResevationDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Bookings", "ToDate");
            DropColumn("dbo.Bookings", "FromDate");
            DropColumn("dbo.Bookings", "Status");
        }
    }
}
