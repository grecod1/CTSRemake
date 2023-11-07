namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQLPopulateNoteTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE NoteTypes SET Name = 'Caller Comments' WHERE Id = 1");
            Sql("UPDATE NoteTypes SET Name = 'Resolution' WHERE Id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
