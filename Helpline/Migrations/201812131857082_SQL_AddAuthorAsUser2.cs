namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQL_AddAuthorAsUser2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Users(UserName, FirstName, LastName, RoleId, OfficeLocationId, IsActive, CreatedBy_UserName, CreationDate, LastModifiedBy_UserName, ModifiedDate)"
                + "VALUES('DOACS/grecod', 'Daniel', 'Greco', 1, 1, 'true', 'DOACS/grecod', '12/13/2018', 'DOACS/grecod', '12/13/2018')");
        }
        
        public override void Down()
        {
        }
    }
}
