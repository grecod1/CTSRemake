namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTicketForiegnKeyToEmailClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Emails", "TicketId", c => c.Int(nullable: false));
            CreateIndex("dbo.Emails", "TicketId");
            AddForeignKey("dbo.Emails", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Emails", "TicketId", "dbo.Tickets");
            DropIndex("dbo.Emails", new[] { "TicketId" });
            DropColumn("dbo.Emails", "TicketId");
        }
    }
}
