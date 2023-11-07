namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "MailedInfo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tickets", "Email", c => c.String());
            AddColumn("dbo.Tickets", "Resolution", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "Resolution");
            DropColumn("dbo.Tickets", "Email");
            DropColumn("dbo.Tickets", "MailedInfo");
        }
    }
}
