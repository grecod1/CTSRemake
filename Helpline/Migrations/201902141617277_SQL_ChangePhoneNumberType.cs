namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQL_ChangePhoneNumberType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE PhoneTypes SET PhoneTypeName = 'Mobile Number' WHERE Id = 3");
        }
        
        public override void Down()
        {
        }
    }
}
