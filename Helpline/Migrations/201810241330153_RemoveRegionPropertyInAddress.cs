namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRegionPropertyInAddress : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "RegionId", "dbo.Regions");
            DropIndex("dbo.Addresses", new[] { "RegionId" });
            DropColumn("dbo.Addresses", "RegionId");
            DropTable("dbo.Regions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Addresses", "RegionId", c => c.Int());
            CreateIndex("dbo.Addresses", "RegionId");
            AddForeignKey("dbo.Addresses", "RegionId", "dbo.Regions", "Id");
        }
    }
}
