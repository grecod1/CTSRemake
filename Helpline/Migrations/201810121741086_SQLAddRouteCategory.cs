namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQLAddRouteCategory : DbMigration
    {
        public override void Up()
        {
            //Sql("INSERT INTO RoutingCategories(Name, ParentCategoryId, Email, Shift, IsActive, CreatedBy_UserId, CreationDate, LastModifiedBy_UserId, ModifiedDate ) VALUES('African Honeybee', 0,'Africanhoneybee@email.com', 'Default', 'True', 1, '10/12/2018', 1, '10/12/2018')");
            //Sql("INSERT INTO RoutingCategories(Name, ParentCategoryId, Email, Shift, IsActive, CreatedBy_UserId, CreationDate, LastModifiedBy_UserId, ModifiedDate ) VALUES('Flat worm', 0,'mary.yongcong@email.com', 'Default', 'True', 1, '10/12/2018', 1, '10/12/2018')");
            //Sql("INSERT INTO RoutingCategories(Name, ParentCategoryId, Email, Shift, IsActive, CreatedBy_UserId, CreationDate, LastModifiedBy_UserId, ModifiedDate ) VALUES('GALS Survey', 0,'GALS@email.com', 'Default', 'True', 1, '10/12/2018', 1, '10/12/2018')");
            //Sql("INSERT INTO RoutingCategories(Name, ParentCategoryId, Email, Shift, IsActive, CreatedBy_UserId, CreationDate, LastModifiedBy_UserId, ModifiedDate ) VALUES('Plant Inspection', 0,'R1@email.com', 'Default', 'True', 1, '10/12/2018', 1, '10/12/2018')");
        }
        
        public override void Down()
        {
        }
    }
}
