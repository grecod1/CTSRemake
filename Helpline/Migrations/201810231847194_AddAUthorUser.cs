namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAUthorUser : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Users(UserName, Password, FirstName, LastName, RoleId, OfficeLocationId, IsActive, CreatedBy_UserId, CreationDate, LastModifiedBy_UserId, ModifiedDate)" +
                "VALUES('Author', 'password','Daniel','Greco', 1, 12, 'true', 5, 10/23/2018, 5, 10/23/2018 )");
        }
        
        public override void Down()
        {
        }
    }
}
