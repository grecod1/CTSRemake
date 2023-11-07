namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQLClearTicketAndContactTable : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Tickets");
            Sql("DELETE FROM Contacts");
        }
        
        public override void Down()
        {
        }
    }
}
