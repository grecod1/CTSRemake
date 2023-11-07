namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePropertyNameFromRepsonseTypeToNoteType : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Notes", "NoteType_Id", "dbo.NoteTypes");
            //DropIndex("dbo.Notes", new[] { "NoteType_Id" });
            //RenameColumn(table: "dbo.Notes", name: "NoteType_Id", newName: "NoteTypeId");
            //AddColumn("dbo.NoteTypes", "Name", c => c.String());
            //AlterColumn("dbo.Notes", "NoteTypeId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Notes", "NoteTypeId");
            //AddForeignKey("dbo.Notes", "NoteTypeId", "dbo.NoteTypes", "Id", cascadeDelete: true);
            //DropColumn("dbo.Notes", "ResponseTypeId");
            //DropColumn("dbo.NoteTypes", "Response");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NoteTypes", "Response", c => c.String());
            AddColumn("dbo.Notes", "ResponseTypeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Notes", "NoteTypeId", "dbo.NoteTypes");
            DropIndex("dbo.Notes", new[] { "NoteTypeId" });
            AlterColumn("dbo.Notes", "NoteTypeId", c => c.Int());
            DropColumn("dbo.NoteTypes", "Name");
            RenameColumn(table: "dbo.Notes", name: "NoteTypeId", newName: "NoteType_Id");
            CreateIndex("dbo.Notes", "NoteType_Id");
            AddForeignKey("dbo.Notes", "NoteType_Id", "dbo.NoteTypes", "Id");
        }
    }
}
