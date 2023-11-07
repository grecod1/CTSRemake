namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTicketForiegnKeyToPhoneNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhoneNumbers", "TicketId", c => c.Int(nullable: false));
            CreateIndex("dbo.PhoneNumbers", "TicketId");
            AddForeignKey("dbo.PhoneNumbers", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhoneNumbers", "TicketId", "dbo.Tickets");
            DropIndex("dbo.PhoneNumbers", new[] { "TicketId" });
            DropColumn("dbo.PhoneNumbers", "TicketId");
        }
    }
}
