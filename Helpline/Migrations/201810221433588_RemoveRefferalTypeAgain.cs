namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRefferalTypeAgain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "ReferralTypeId", "dbo.ReferralTypes");
            DropIndex("dbo.Tickets", new[] { "ReferralTypeId" });
            DropColumn("dbo.Tickets", "ReferralTypeId");
            DropTable("dbo.ReferralTypes");
        }

        public override void Down()
        {
        }
    }
}
