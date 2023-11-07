namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForiegnKeyRelation : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.Routes", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
        }
    }
}
