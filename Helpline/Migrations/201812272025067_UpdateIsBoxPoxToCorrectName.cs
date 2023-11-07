namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIsBoxPoxToCorrectName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "IsPOBox", c => c.Boolean(nullable: false));
            DropColumn("dbo.Addresses", "IsBoxBox");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "IsBoxBox", c => c.Boolean(nullable: false));
            DropColumn("dbo.Addresses", "IsPOBox");
        }
    }
}
