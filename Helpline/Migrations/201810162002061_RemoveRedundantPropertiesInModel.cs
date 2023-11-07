namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRedundantPropertiesInModel : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Notes");
            AddColumn("dbo.Notes", "TicketId", c => c.Int(nullable: false));
            CreateIndex("dbo.Notes", "TicketId");
            AddForeignKey("dbo.Notes", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
            DropColumn("dbo.Tickets", "CallersRemark");
            DropColumn("dbo.Tickets", "Comments");
            DropColumn("dbo.Tickets", "Resolution");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "Resolution", c => c.String());
            AddColumn("dbo.Tickets", "Comments", c => c.String());
            AddColumn("dbo.Tickets", "CallersRemark", c => c.String());
            DropForeignKey("dbo.Notes", "TicketId", "dbo.Tickets");
            DropIndex("dbo.Notes", new[] { "TicketId" });
            DropColumn("dbo.Notes", "TicketId");
        }
    }
}
