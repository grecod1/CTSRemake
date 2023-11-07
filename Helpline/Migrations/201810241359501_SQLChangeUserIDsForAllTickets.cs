namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQLChangeUserIDsForAllTickets : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Tickets SET UserId = 6");
        }
        
        public override void Down()
        {
        }
    }
}
