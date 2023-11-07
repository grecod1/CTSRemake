namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQLClearTicketTable : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Tickets");
        }
        
        public override void Down()
        {
        }
    }
}
