namespace GetSetGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLastUpdatedToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "LastUpdated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "LastUpdated");
        }
    }
}
