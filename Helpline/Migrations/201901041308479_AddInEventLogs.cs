namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInEventLogs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventTypeId = c.Int(nullable: false),
                        CreatedBy_UserName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventTypes", t => t.EventTypeId, cascadeDelete: true)
                .Index(t => t.EventTypeId);
            
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventTypeName = c.String(),
                        CreatedBy_UserName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventLogs", "EventTypeId", "dbo.EventTypes");
            DropIndex("dbo.EventLogs", new[] { "EventTypeId" });
            DropTable("dbo.EventTypes");
            DropTable("dbo.EventLogs");
        }
    }
}
