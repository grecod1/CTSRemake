namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddThreeNewPropertiesToTicketModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "Affiliation", c => c.String());
            AddColumn("dbo.Tickets", "Bureau", c => c.String());
            AddColumn("dbo.Tickets", "ReferredFrom", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "ReferredFrom");
            DropColumn("dbo.Tickets", "Bureau");
            DropColumn("dbo.Tickets", "Affiliation");
        }
    }
}
