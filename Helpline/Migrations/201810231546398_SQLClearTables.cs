namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQLClearTables : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Addresses");
            Sql("DELETE FROM PhoneNumbers");
            Sql("DELETE FROM Emails");
            Sql("DELETE FROM Contacts");
            Sql("DELETE FROM Notes");
            Sql("DELETE FROM Programs");
            Sql("DELETE FROM RequestTypes");
            Sql("DELETE FROM RoutingCategories");
            Sql("DELETE FROM Routes");
            Sql("DELETE FROM Status");
            Sql("DELETE FROM Tickets");
        }
        
        public override void Down()
        {

        }
    }
}
