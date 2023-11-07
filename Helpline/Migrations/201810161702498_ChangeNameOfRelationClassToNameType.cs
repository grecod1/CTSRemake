namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNameOfRelationClassToNameType : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Relations", newName: "NameTypes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.NameTypes", newName: "Relations");
        }
    }
}
