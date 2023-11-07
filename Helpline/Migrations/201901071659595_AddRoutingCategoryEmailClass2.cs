namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoutingCategoryEmailClass2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoutingEmails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoutingCategoryId = c.Int(nullable: false),
                        EmailAddress = c.String(),
                        CreatedBy_UserName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserName = c.String(),
                        ModificationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoutingCategories", t => t.RoutingCategoryId, cascadeDelete: true)
                .Index(t => t.RoutingCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoutingEmails", "RoutingCategoryId", "dbo.RoutingCategories");
            DropIndex("dbo.RoutingEmails", new[] { "RoutingCategoryId" });
            DropTable("dbo.RoutingEmails");
        }
    }
}
