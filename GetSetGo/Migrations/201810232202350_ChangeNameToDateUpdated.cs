namespace GetSetGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNameToDateUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DateUpdated", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customers", "LastUpdated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "LastUpdated", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customers", "DateUpdated");
        }
    }
}
