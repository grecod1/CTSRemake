namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQLFixNoteTableByAddingDefaultValues : DbMigration
    {
        public override void Up()
        {
            //Sql("UPDATE Notes SET ResponseTypeId = 1 WHERE ResponseTypeId IS NULL");
        }
        
        public override void Down()
        {
        }
    }
}
