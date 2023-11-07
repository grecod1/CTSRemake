namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixUserTable : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Users WHERE Id != 1");
        }
        
        public override void Down()
        {
        }
    }
}
