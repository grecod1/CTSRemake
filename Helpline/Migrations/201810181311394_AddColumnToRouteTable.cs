namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnToRouteTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Routes", "IsActive", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
        }
    }
}
