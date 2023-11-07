namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsPoBoxBooleanFieldToAddressClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "IsBoxBox", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Addresses", "IsBoxBox");
        }
    }
}
