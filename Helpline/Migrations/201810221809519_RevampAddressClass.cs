namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevampAddressClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "StreetAddress", c => c.String());
            DropColumn("dbo.Addresses", "StreetNumber");
            DropColumn("dbo.Addresses", "StreetDirection");
            DropColumn("dbo.Addresses", "StreetName");
            DropColumn("dbo.Addresses", "LotNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "LotNumber", c => c.String());
            AddColumn("dbo.Addresses", "StreetName", c => c.String());
            AddColumn("dbo.Addresses", "StreetDirection", c => c.String());
            AddColumn("dbo.Addresses", "StreetNumber", c => c.String());
            DropColumn("dbo.Addresses", "StreetAddress");
        }
    }
}
