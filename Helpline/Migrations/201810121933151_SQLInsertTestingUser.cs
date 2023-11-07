namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQLInsertTestingUser : DbMigration
    {
        public override void Up()
        {
            //Sql("INSERT INTO Users(UserName, Password, FirstName, LastName, RoleId, OfficeLocationId, IsActive, CreatedBy_UserId, CreationDate, LastModifiedBy_UserId, ModifiedDate) VALUES('Tester', 'password', 'FirstName', 'LastName', 1, 1, 'True', 1, '10/12/2018', 1, '10/12/2018' )");
        }
        
        public override void Down()
        {
        }
    }
}
