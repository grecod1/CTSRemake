namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQLPopulateResponseTypeTable_FixNoteTable : DbMigration
    {
        public override void Up()
        {
            //Sql("INSERT INTO ResponseTypes(Response, CreatedBy_UserId, CreationDate, LastModifiedBy_UserId, ModifiedDate) VALUES('Caller Comments', 3, '10/15/2018', 3, '10/15/2018' )");
            //Sql("INSERT INTO ResponseTypes(Response, CreatedBy_UserId, CreationDate, LastModifiedBy_UserId, ModifiedDate) VALUES('Resolution', 3, '10/15/2018', 3, '10/15/2018' )");            
        }
        
        public override void Down()
        {
        }
    }
}
