namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQL_EditUserNamesInTicketTable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Tickets SET UserId = 'Author'");
            Sql("UPDATE Tickets SET CreatedBy_UserName = 'Author'");
            Sql("UPDATE Tickets SET LastModifiedBy_UserName = 'Author'");
        }
        
        public override void Down()
        {
        }
    }
}
