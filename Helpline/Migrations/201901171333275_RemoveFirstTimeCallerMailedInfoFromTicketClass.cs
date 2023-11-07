namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveFirstTimeCallerMailedInfoFromTicketClass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tickets", "MailedInfo");
            DropColumn("dbo.Tickets", "FirstTimeCaller");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "FirstTimeCaller", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tickets", "MailedInfo", c => c.Boolean(nullable: false));
        }
    }
}
