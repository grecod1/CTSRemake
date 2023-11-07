namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Route_to_Ticket : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Tickets", "RouteId");
            AddForeignKey("dbo.Tickets", "RouteId", "dbo.Routes", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "RouteId", "dbo.Routes");
            DropIndex("dbo.Tickets", new[] { "RouteId" });
        }
    }
}
