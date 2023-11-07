namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFirstNameAndLastNameToTicketClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "FirstName", c => c.String());
            AddColumn("dbo.Tickets", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "LastName");
            DropColumn("dbo.Tickets", "FirstName");
        }
    }
}
