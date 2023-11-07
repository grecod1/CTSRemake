namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateResponseTypeTable : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.ResponseTypes",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Response = c.String(),
            //            CreatedBy_UserId = c.Int(nullable: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            LastModifiedBy_UserId = c.Int(nullable: false),
            //            ModifiedDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //AddColumn("dbo.Notes", "ResponseTypeId", c => c.Int(nullable: true));
            //CreateIndex("dbo.Notes", "ResponseTypeId");
            //AddForeignKey("dbo.Notes", "ResponseTypeId", "dbo.ResponseTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "ResponseTypeId", "dbo.ResponseTypes");
            DropIndex("dbo.Notes", new[] { "ResponseTypeId" });
            DropColumn("dbo.Notes", "ResponseTypeId");
            DropTable("dbo.ResponseTypes");
        }
    }
}
