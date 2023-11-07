namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedNameOfResponseTypeToNoteType : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.ResponseTypes", newName: "NoteTypes");
            //DropForeignKey("dbo.Notes", "ResponseTypeId", "dbo.ResponseTypes");
            //DropIndex("dbo.Notes", new[] { "ResponseTypeId" });
            //AddColumn("dbo.Notes", "NoteType_Id", c => c.Int());
            //CreateIndex("dbo.Notes", "NoteType_Id");
            //AddForeignKey("dbo.Notes", "NoteType_Id", "dbo.NoteTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "NoteType_Id", "dbo.NoteTypes");
            DropIndex("dbo.Notes", new[] { "NoteType_Id" });
            DropColumn("dbo.Notes", "NoteType_Id");
            CreateIndex("dbo.Notes", "ResponseTypeId");
            AddForeignKey("dbo.Notes", "ResponseTypeId", "dbo.ResponseTypes", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.NoteTypes", newName: "ResponseTypes");
        }
    }
}
