namespace GetSetGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVehiclePlateNumberAndColor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "PlateNumber", c => c.String());
            AddColumn("dbo.Vehicles", "Color", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "Color");
            DropColumn("dbo.Vehicles", "PlateNumber");
        }
    }
}
