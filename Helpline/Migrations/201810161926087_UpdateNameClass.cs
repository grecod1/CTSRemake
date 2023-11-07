namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNameClass : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Names");

            CreateTable(
                "dbo.TicketNames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        NameId = c.Int(nullable: false),
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Names", t => t.NameId, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId)
                .Index(t => t.NameId);
            
            AddColumn("dbo.Names", "ContactId", c => c.Int(nullable: false));
            CreateIndex("dbo.Names", "ContactId");
            AddForeignKey("dbo.Names", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketNames", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketNames", "NameId", "dbo.Names");
            DropForeignKey("dbo.Names", "ContactId", "dbo.Contacts");
            DropIndex("dbo.TicketNames", new[] { "NameId" });
            DropIndex("dbo.TicketNames", new[] { "TicketId" });
            DropIndex("dbo.Names", new[] { "ContactId" });
            DropColumn("dbo.Names", "ContactId");
            DropTable("dbo.TicketNames");
        }
    }
}
