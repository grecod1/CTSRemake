namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeTicketNoteObject : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TicketNotes", "NoteId", "dbo.Notes");
            DropForeignKey("dbo.TicketNotes", "TicketId", "dbo.Tickets");
            DropIndex("dbo.TicketNotes", new[] { "TicketId" });
            DropIndex("dbo.TicketNotes", new[] { "NoteId" });
            //DropTable("dbo.TicketNotes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TicketNotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        NoteId = c.Int(nullable: false),
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.TicketNotes", "NoteId");
            CreateIndex("dbo.TicketNotes", "TicketId");
            AddForeignKey("dbo.TicketNotes", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TicketNotes", "NoteId", "dbo.Notes", "Id", cascadeDelete: true);
        }
    }
}
