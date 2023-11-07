namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCallerForiegnKeyOnPhoneNumber : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhoneNumbers", "ContactId", "dbo.Callers");
            DropIndex("dbo.PhoneNumbers", new[] { "ContactId" });
            DropColumn("dbo.PhoneNumbers", "ContactId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhoneNumbers", "ContactId", c => c.Int(nullable: false));
            CreateIndex("dbo.PhoneNumbers", "ContactId");
            AddForeignKey("dbo.PhoneNumbers", "ContactId", "dbo.Callers", "Id", cascadeDelete: true);
        }
    }
}
