namespace GetSetGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateAddedAndModifiedToVehicle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vehicles", "DateUpdated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "DateUpdated");
            DropColumn("dbo.Vehicles", "DateAdded");
        }
    }
}
