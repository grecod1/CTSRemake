namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTicketWithNoRoute : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM tickets Where Id = 18");
        }
        
        public override void Down()
        {
        }
    }
}
