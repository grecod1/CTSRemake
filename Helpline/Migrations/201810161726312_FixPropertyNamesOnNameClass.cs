namespace Helpline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixPropertyNamesOnNameClass : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Names", name: "RelationId", newName: "NameTypeId");
            RenameIndex(table: "dbo.Names", name: "IX_RelationId", newName: "IX_NameTypeId");
            AddColumn("dbo.NameTypes", "Name_Type", c => c.String());
            DropColumn("dbo.NameTypes", "RequestRelation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NameTypes", "RequestRelation", c => c.String());
            DropColumn("dbo.NameTypes", "Name_Type");
            RenameIndex(table: "dbo.Names", name: "IX_NameTypeId", newName: "IX_RelationId");
            RenameColumn(table: "dbo.Names", name: "NameTypeId", newName: "RelationId");
        }
    }
}
