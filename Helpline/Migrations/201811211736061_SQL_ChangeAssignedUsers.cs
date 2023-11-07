namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQL_ChangeAssignedUsers : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Tickets SET UserId = 'daniel.greco@freshfromflorida.com' WHERE UserId = '1'");
        }
        
        public override void Down()
        {
        }
    }
}
