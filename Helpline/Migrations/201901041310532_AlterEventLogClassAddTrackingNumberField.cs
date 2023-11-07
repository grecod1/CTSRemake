namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterEventLogClassAddTrackingNumberField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventLogs", "TicketTrackingNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EventLogs", "TicketTrackingNumber");
        }
    }
}
