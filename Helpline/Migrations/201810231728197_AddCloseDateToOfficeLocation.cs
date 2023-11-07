namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCloseDateToOfficeLocation : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM OfficeLocations");
            AddColumn("dbo.OfficeLocations", "CloseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OfficeLocations", "CloseDate");
        }
    }
}
