namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveContactIdForiegnkeyOnAddressAndEmail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "ContactId", "dbo.Callers");
            DropForeignKey("dbo.Emails", "ContactId", "dbo.Callers");
            DropIndex("dbo.Addresses", new[] { "ContactId" });
            DropIndex("dbo.Emails", new[] { "ContactId" });
            DropColumn("dbo.Addresses", "ContactId");
            DropColumn("dbo.Emails", "ContactId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Emails", "ContactId", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "ContactId", c => c.Int(nullable: false));
            CreateIndex("dbo.Emails", "ContactId");
            CreateIndex("dbo.Addresses", "ContactId");
            AddForeignKey("dbo.Emails", "ContactId", "dbo.Callers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "ContactId", "dbo.Callers", "Id", cascadeDelete: true);
        }
    }
}
