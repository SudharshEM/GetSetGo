namespace GetSetGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerIdAndVehicleIdInRentals : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Rentals", name: "Customer_Id", newName: "CustomerId");
            RenameColumn(table: "dbo.Rentals", name: "Vehicle_Id", newName: "VehicleId");
            RenameIndex(table: "dbo.Rentals", name: "IX_Customer_Id", newName: "IX_CustomerId");
            RenameIndex(table: "dbo.Rentals", name: "IX_Vehicle_Id", newName: "IX_VehicleId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Rentals", name: "IX_VehicleId", newName: "IX_Vehicle_Id");
            RenameIndex(table: "dbo.Rentals", name: "IX_CustomerId", newName: "IX_Customer_Id");
            RenameColumn(table: "dbo.Rentals", name: "VehicleId", newName: "Vehicle_Id");
            RenameColumn(table: "dbo.Rentals", name: "CustomerId", newName: "Customer_Id");
        }
    }
}
