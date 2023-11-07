namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCallerClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Callers", "TicketId", "dbo.Tickets");
            DropIndex("dbo.Callers", new[] { "TicketId" });
            DropTable("dbo.Callers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Callers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CreatedBy_UserName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Callers", "TicketId");
            AddForeignKey("dbo.Callers", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
        }
    }
}
