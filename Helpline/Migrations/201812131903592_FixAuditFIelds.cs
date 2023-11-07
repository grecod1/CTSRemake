namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixAuditFIelds : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Roles SET CreatedBy_UserName = 'DOACS\\grecod', LastModifiedBy_UserName = 'DOACS\\grecod'");
            Sql("UPDATE OfficeLocations SET CreatedBy_UserName = 'DOACS\\grecod', LastModifiedBy_UserName = 'DOACS\\grecod'");
            Sql("UPDATE Users SET UserName = 'DOACS\\grecod', CreatedBy_UserName = 'DOACS\\grecod', LastModifiedBy_UserName = 'DOACS\\grecod'");
        }
        
        public override void Down()
        {
        }
    }
}
