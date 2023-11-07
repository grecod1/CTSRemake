namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveContactTypePropertyFromCallerClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Callers", "ContactTypeId", "dbo.ContactTypes");
            DropIndex("dbo.Callers", new[] { "ContactTypeId" });
            DropColumn("dbo.Callers", "ContactTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Callers", "ContactTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Callers", "ContactTypeId");
            AddForeignKey("dbo.Callers", "ContactTypeId", "dbo.ContactTypes", "Id", cascadeDelete: true);
        }
    }
}
