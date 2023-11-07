namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRouteTicketRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Routes", "TicketId", "dbo.Tickets");
            DropIndex("dbo.Routes", new[] { "TicketId" });            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Routes", "TicketId", c => c.Int(nullable: false));
            CreateIndex("dbo.Routes", "TicketId");
            AddForeignKey("dbo.Routes", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
        }
    }
}
