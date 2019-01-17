namespace GetSetGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredAttributeToVehicelTypeName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VehicleTypes", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VehicleTypes", "Name", c => c.String());
        }
    }
}
