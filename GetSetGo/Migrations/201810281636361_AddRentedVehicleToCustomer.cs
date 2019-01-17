namespace GetSetGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentedVehicleToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "RentedVehicleId", c => c.Int());
            CreateIndex("dbo.Customers", "RentedVehicleId");
            AddForeignKey("dbo.Customers", "RentedVehicleId", "dbo.Vehicles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "RentedVehicleId", "dbo.Vehicles");
            DropIndex("dbo.Customers", new[] { "RentedVehicleId" });
            DropColumn("dbo.Customers", "RentedVehicleId");
        }
    }
}
