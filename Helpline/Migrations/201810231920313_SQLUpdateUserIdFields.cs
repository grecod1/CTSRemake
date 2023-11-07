namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQLUpdateUserIdFields : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Users SET CreatedBy_UserId = 6, LastModifiedBy_UserID = 6");
            Sql("UPDATE OfficeLocations SET CreatedBy_UserId = 6, LastModifiedBy_UserId = 6");
        }
        
        public override void Down()
        {
        }
    }
}
