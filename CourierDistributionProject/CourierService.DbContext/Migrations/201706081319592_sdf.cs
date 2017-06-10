namespace CourierService.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdf : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Offices", name: "City_Id", newName: "CityId");
            RenameIndex(table: "dbo.Offices", name: "IX_City_Id", newName: "IX_CityId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Offices", name: "IX_CityId", newName: "IX_City_Id");
            RenameColumn(table: "dbo.Offices", name: "CityId", newName: "City_Id");
        }
    }
}
