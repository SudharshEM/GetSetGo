namespace GetSetGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvailabilityToVehicles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "Availability", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "Availability");
        }
    }
}
