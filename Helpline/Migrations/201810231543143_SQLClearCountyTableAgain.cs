namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQLClearCountyTableAgain : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Counties");
        }
        
        public override void Down()
        {
        }
    }
}
