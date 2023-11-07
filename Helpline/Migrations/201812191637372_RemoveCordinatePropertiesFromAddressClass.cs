namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCordinatePropertiesFromAddressClass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Addresses", "Latitude");
            DropColumn("dbo.Addresses", "Longitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "Longitude", c => c.Double(nullable: false));
            AddColumn("dbo.Addresses", "Latitude", c => c.Double(nullable: false));
        }
    }
}
