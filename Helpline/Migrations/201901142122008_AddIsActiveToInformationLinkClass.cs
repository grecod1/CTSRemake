namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsActiveToInformationLinkClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InformationLinks", "IsActive", c => c.Boolean(nullable: false));
            Sql("UPDATE InformationLinks SET IsActive = 'true'");
        }
        
        public override void Down()
        {
            DropColumn("dbo.InformationLinks", "IsActive");
        }
    }
}
