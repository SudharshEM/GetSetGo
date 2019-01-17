namespace GetSetGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateVehicleTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO VehicleTypes VALUES(1,'Bike')");
            Sql("INSERT INTO VehicleTypes VALUES(2,'Motorcycle')");
            Sql("INSERT INTO VehicleTypes VALUES(3,'Car')");
        }
        
        public override void Down()
        {
        }
    }
}
