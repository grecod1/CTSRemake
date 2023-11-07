namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAreaPropertyToAdminModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RequestTypes", "Area", c => c.String());
            AddColumn("dbo.RoutingCategories", "Area", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoutingCategories", "Area");
            DropColumn("dbo.RequestTypes", "Area");
        }
    }
}
