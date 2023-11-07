namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQLAddRestOfPhoneTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO PhoneTypes(PhoneTypeName, isActive, CreatedBy_UserId, CreationDate, LastModifiedBy_UserId, ModifiedDate) VALUES('Work', 1 , 1 , '10/12/2018', 1, '10/12/2018' )");
            Sql("INSERT INTO PhoneTypes(PhoneTypeName, isActive, CreatedBy_UserId, CreationDate, LastModifiedBy_UserId, ModifiedDate) VALUES('Fax', 1 , 1 , '10/12/2018', 1, '10/12/2018' )");
        }
        
        public override void Down()
        {
        }
    }
}
