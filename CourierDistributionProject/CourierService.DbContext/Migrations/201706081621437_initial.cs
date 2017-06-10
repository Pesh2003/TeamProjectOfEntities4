namespace CourierService.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ServiceOptions", name: "ServicesType_Id", newName: "ServicesTypeId");
            RenameIndex(table: "dbo.ServiceOptions", name: "IX_ServicesType_Id", newName: "IX_ServicesTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ServiceOptions", name: "IX_ServicesTypeId", newName: "IX_ServicesType_Id");
            RenameColumn(table: "dbo.ServiceOptions", name: "ServicesTypeId", newName: "ServicesType_Id");
        }
    }
}
