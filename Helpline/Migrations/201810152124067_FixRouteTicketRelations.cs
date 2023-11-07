namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixRouteTicketRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "ProgramId", "dbo.Programs");
            DropIndex("dbo.Tickets", new[] { "ProgramId" });
            DropColumn("dbo.Tickets", "ProgramId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "ProgramId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "ProgramId");
            AddForeignKey("dbo.Tickets", "ProgramId", "dbo.Programs", "Id", cascadeDelete: true);
        }
    }
}
