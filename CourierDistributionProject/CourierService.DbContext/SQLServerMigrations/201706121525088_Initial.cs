namespace CourierService.DbContext.SQLServerMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Offices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false, maxLength: 150),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Details = c.String(nullable: false, storeType: "ntext"),
                        IsTaken = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        OfficeId = c.Int(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                        UserFixerId = c.Int(nullable: false),
                        City_Id = c.Int(nullable: false),
                        ServiceOption_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id, cascadeDelete: true)
                .ForeignKey("dbo.ServiceOptions", t => t.ServiceOption_Id, cascadeDelete: true)
                .Index(t => t.City_Id)
                .Index(t => t.ServiceOption_Id);
            
            CreateTable(
                "dbo.ServiceOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServicesTypeId = c.Int(nullable: false),
                        Weight = c.Double(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TimeDuration = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServicesTypes", t => t.ServicesTypeId, cascadeDelete: true)
                .Index(t => t.ServicesTypeId);
            
            CreateTable(
                "dbo.ServicesTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceType = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ServiceType, unique: true, name: "IX_ServicesType");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "ServiceOption_Id", "dbo.ServiceOptions");
            DropForeignKey("dbo.ServiceOptions", "ServicesTypeId", "dbo.ServicesTypes");
            DropForeignKey("dbo.Services", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Offices", "CityId", "dbo.Cities");
            DropIndex("dbo.ServicesTypes", "IX_ServicesType");
            DropIndex("dbo.ServiceOptions", new[] { "ServicesTypeId" });
            DropIndex("dbo.Services", new[] { "ServiceOption_Id" });
            DropIndex("dbo.Services", new[] { "City_Id" });
            DropIndex("dbo.Offices", new[] { "CityId" });
            DropTable("dbo.ServicesTypes");
            DropTable("dbo.ServiceOptions");
            DropTable("dbo.Services");
            DropTable("dbo.Offices");
            DropTable("dbo.Cities");
        }
    }
}
