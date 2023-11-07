namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQL_RemoveIllegitimateOfficeLocation : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM OfficeLocations WHERE Id = 5");
        }
        
        public override void Down()
        {
        }
    }
}
