namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClearRegionTable : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Regions");
        }
        
        public override void Down()
        {
        }
    }
}
