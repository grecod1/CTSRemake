namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PossibleDataBaseUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RoutingCategories", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RoutingCategories", "Name", c => c.String(nullable: false));
        }
    }
}
