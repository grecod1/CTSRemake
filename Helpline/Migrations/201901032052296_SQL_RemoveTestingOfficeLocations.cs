namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQL_RemoveTestingOfficeLocations : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM OfficeLocations WHERE Id = 6");
            Sql("DELETE FROM OfficeLocations WHERE Id = 7");
        }
        
        public override void Down()
        {
        }
    }
}
