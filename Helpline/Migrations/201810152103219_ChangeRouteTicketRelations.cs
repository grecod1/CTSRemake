namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRouteTicketRelations : DbMigration
    {
        public override void Up()
        {            
            DropForeignKey("dbo.Tickets", "RouteId", "dbo.Routes");
            DropIndex("dbo.Tickets", new[] { "RouteId" });            
            DropColumn("dbo.Tickets", "RouteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "RouteId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Routes", "TicketId", "dbo.Tickets");
            DropIndex("dbo.Routes", new[] { "TicketId" });
            DropColumn("dbo.Routes", "IsActive");
            DropColumn("dbo.Routes", "TicketId");
            CreateIndex("dbo.Tickets", "RouteId");
            AddForeignKey("dbo.Tickets", "RouteId", "dbo.Routes", "Id", cascadeDelete: true);
        }
    }
}
