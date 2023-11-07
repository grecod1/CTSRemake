namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNameType : DbMigration
    {
        public override void Up()
        {

            //DropForeignKey("dbo.Names", "NameTypeId", "dbo.NameTypes");
            //DropIndex("dbo.Names", new[] { "NameTypeId" });
            //DropColumn("dbo.Names", "NameTypeId");
            //DropTable("dbo.NameTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.NameTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name_Type = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Names", "NameTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Names", "NameTypeId");
            AddForeignKey("dbo.Names", "NameTypeId", "dbo.NameTypes", "Id", cascadeDelete: true);
        }
    }
}
