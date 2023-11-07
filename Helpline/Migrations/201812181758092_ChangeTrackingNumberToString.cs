namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTrackingNumberToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "TrackingNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "TrackingNumber", c => c.Int(nullable: false));
        }
    }
}
