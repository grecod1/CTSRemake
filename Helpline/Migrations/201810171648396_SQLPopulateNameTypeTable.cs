namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQLPopulateNameTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE NameTypes SET Name_Type = 'Caller' WHERE Id = 1 ");
        }
        
        public override void Down()
        {
        }
    }
}
