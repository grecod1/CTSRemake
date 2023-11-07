namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveParentCategoryIdFromRouteCategoryTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoutingCategories", "ParentCategoryId", "dbo.RoutingCategories");
            DropIndex("dbo.RoutingCategories", new[] { "ParentCategoryId" });
            DropColumn("dbo.RoutingCategories", "ParentCategoryId");
            Sql("INSERT INTO RoutingCategories(Name, Email, Shift, IsActive, CreatedBy_UserId, CreationDate, LastModifiedBy_UserId, ModifiedDate ) VALUES('African Honeybee','Africanhoneybee@email.com', 'Default', 'True', 1, '10/12/2018', 1, '10/12/2018')");
            Sql("INSERT INTO RoutingCategories(Name, Email, Shift, IsActive, CreatedBy_UserId, CreationDate, LastModifiedBy_UserId, ModifiedDate ) VALUES('Flat worm','mary.yongcong@email.com', 'Default', 'True', 1, '10/12/2018', 1, '10/12/2018')");
            Sql("INSERT INTO RoutingCategories(Name, Email, Shift, IsActive, CreatedBy_UserId, CreationDate, LastModifiedBy_UserId, ModifiedDate ) VALUES('GALS Survey','GALS@email.com', 'Default', 'True', 1, '10/12/2018', 1, '10/12/2018')");
            Sql("INSERT INTO RoutingCategories(Name, Email, Shift, IsActive, CreatedBy_UserId, CreationDate, LastModifiedBy_UserId, ModifiedDate ) VALUES('Plant Inspection','R1@email.com', 'Default', 'True', 1, '10/12/2018', 1, '10/12/2018')");
        }

        public override void Down()
        {
            AddColumn("dbo.RoutingCategories", "ParentCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.RoutingCategories", "ParentCategoryId");
            AddForeignKey("dbo.RoutingCategories", "ParentCategoryId", "dbo.RoutingCategories", "Id");
        }
    }
}
