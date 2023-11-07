namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTicketImageRelation : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Images", "TicketId");
            AddForeignKey("dbo.Images", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "TicketId", "dbo.Tickets");
            DropIndex("dbo.Images", new[] { "TicketId" });
        }
    }
}
