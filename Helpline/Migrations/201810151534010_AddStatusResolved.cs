namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusResolved : DbMigration
    {
        public override void Up()
        {
            //Sql("INSERT INTO Status(Name, IsActive, CreatedBy_UserId, CreationDate, LastModifiedBy_UserId, ModifiedDate) VALUES('Resolved', 'True', 3, '10/15/2018',3, '10/15/2018')");
        }
        
        public override void Down()
        {
        }
    }
}
