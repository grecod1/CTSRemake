namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailToEventLog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventLogs", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EventLogs", "Email");
        }
    }
}
