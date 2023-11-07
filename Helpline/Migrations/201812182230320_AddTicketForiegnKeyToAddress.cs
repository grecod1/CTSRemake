namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTicketForiegnKeyToAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "TicketId", c => c.Int(nullable: false));
            CreateIndex("dbo.Addresses", "TicketId");
            AddForeignKey("dbo.Addresses", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "TicketId", "dbo.Tickets");
            DropIndex("dbo.Addresses", new[] { "TicketId" });
            DropColumn("dbo.Addresses", "TicketId");
        }
    }
}
