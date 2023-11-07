namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateRefferalTypeRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReferralTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedBy_UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedBy_UserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tickets", "ReferralTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "ReferralTypeId");
            AddForeignKey("dbo.Tickets", "ReferralTypeId", "dbo.ReferralTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "ReferralTypeId", "dbo.ReferralTypes");
            DropIndex("dbo.Tickets", new[] { "ReferralTypeId" });
            DropColumn("dbo.Tickets", "ReferralTypeId");
            DropTable("dbo.ReferralTypes");
        }
    }
}
