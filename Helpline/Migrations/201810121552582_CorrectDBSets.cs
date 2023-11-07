namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectDBSets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Names",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RelationId = c.Int(nullable: false),
                        Prefix = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Suffix = c.String(),
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Relations", t => t.RelationId, cascadeDelete: true)
                .Index(t => t.RelationId);
            
            CreateTable(
                "dbo.Relations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestRelation = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Names", "RelationId", "dbo.Relations");
            DropIndex("dbo.Names", new[] { "RelationId" });
            DropTable("dbo.Notes");
            DropTable("dbo.Relations");
            DropTable("dbo.Names");
        }
    }
}
