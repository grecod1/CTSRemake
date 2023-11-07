namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePropertyFromRoutingCategoryClass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RoutingCategories", "Shift");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoutingCategories", "Shift", c => c.String());
        }
    }
}
