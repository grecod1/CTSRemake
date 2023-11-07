namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateNewRelationBetweenRouteTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Routes", "TicketId", c => c.Int(nullable: false));
            CreateIndex("dbo.Routes", "TicketId");
           // AddForeignKey("dbo.Routes", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Routes", "TicketId", "dbo.Tickets");
            DropIndex("dbo.Routes", new[] { "TicketId" });
            DropColumn("dbo.Routes", "TicketId");
        }
    }
}
