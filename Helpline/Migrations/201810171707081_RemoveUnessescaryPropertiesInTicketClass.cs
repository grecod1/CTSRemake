namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUnessescaryPropertiesInTicketClass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tickets", "FirstTimeCaller");
            DropColumn("dbo.Tickets", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "Email", c => c.String());
            AddColumn("dbo.Tickets", "FirstTimeCaller", c => c.Boolean(nullable: false));
        }
    }
}
