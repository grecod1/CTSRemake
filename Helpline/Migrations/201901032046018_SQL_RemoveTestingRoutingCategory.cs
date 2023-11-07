namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQL_RemoveTestingRoutingCategory : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM RoutingCategories WHERE Id = 793");
        }
        
        public override void Down()
        {
        }
    }
}
