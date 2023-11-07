namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRegionPropertyFromTicket : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "RegionId", "dbo.Regions");
            DropIndex("dbo.Tickets", new[] { "RegionId" });
            DropColumn("dbo.Tickets", "RegionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "RegionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "RegionId");
            AddForeignKey("dbo.Tickets", "RegionId", "dbo.Regions", "Id", cascadeDelete: true);
        }
    }
}
