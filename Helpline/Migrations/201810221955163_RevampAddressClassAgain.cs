namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevampAddressClassAgain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "StreetNumber", c => c.String());
            AddColumn("dbo.Addresses", "StreetName", c => c.String());
            AddColumn("dbo.Addresses", "AptNumber", c => c.String());
            DropColumn("dbo.Addresses", "StreetAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "StreetAddress", c => c.String());
            DropColumn("dbo.Addresses", "AptNumber");
            DropColumn("dbo.Addresses", "StreetName");
            DropColumn("dbo.Addresses", "StreetNumber");
        }
    }
}
