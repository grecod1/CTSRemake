namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerPopulatePhoneTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO PhoneTypes(PhoneTypeName, isActive, CreatedBy_UserId, CreationDate, LastModifiedBy_UserId, ModifiedDate) VALUES('Home', 1 , 1 , '10/12/2018', 1, '10/12/2018' )");
        }
        
        public override void Down()
        {
        }
    }
}
