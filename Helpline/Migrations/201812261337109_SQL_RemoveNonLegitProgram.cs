namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SQL_RemoveNonLegitProgram : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Programs WHERE id = 236");
        }
        
        public override void Down()
        {
        }
    }
}
