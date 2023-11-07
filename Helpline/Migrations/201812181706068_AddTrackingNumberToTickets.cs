namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTrackingNumberToTickets : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "TrackingNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "TrackingNumber");
        }
    }
}
