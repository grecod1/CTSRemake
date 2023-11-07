namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetDefaultValuesForTicketForiegnKeyInRouteTable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Routes SET TicketId = 7");
        }
        
        public override void Down()
        {
        }
    }
}
