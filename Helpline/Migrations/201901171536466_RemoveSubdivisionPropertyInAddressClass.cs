namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSubdivisionPropertyInAddressClass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Addresses", "Subdivision");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "Subdivision", c => c.String());
        }
    }
}
