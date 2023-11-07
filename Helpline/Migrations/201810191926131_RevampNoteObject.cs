namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevampNoteObject : DbMigration
    {
        public override void Up()
        {

            
            //DropForeignKey("dbo.Notes", "NoteTypeId", "dbo.NoteTypes");
            //DropIndex("dbo.Notes", new[] { "NoteTypeId" });
            //AddColumn("dbo.Notes", "CallerComments", c => c.String());
            //AddColumn("dbo.Notes", "Resolution", c => c.String());
            //DropColumn("dbo.Notes", "Content");
            //DropColumn("dbo.Notes", "NoteTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notes", "NoteTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Notes", "Content", c => c.String());
            DropColumn("dbo.Notes", "Resolution");
            DropColumn("dbo.Notes", "CallerComments");
            CreateIndex("dbo.Notes", "NoteTypeId");
            AddForeignKey("dbo.Notes", "NoteTypeId", "dbo.NoteTypes", "Id", cascadeDelete: true);
        }
    }
}
