namespace CourierService.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
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
                        City_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id, cascadeDelete: true)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Details = c.String(nullable: false, storeType: "ntext"),
                        IsTaken = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        OfficeId = c.Int(nullable: false),
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
                        Weight = c.Double(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TimeDuration = c.Double(nullable: false),
                        ServicesType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServicesTypes", t => t.ServicesType_Id, cascadeDelete: true)
                .Index(t => t.ServicesType_Id);
            
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
            DropForeignKey("dbo.ServiceOptions", "ServicesType_Id", "dbo.ServicesTypes");
            DropForeignKey("dbo.Services", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Offices", "City_Id", "dbo.Cities");
            DropIndex("dbo.ServicesTypes", "IX_ServicesType");
            DropIndex("dbo.ServiceOptions", new[] { "ServicesType_Id" });
            DropIndex("dbo.Services", new[] { "ServiceOption_Id" });
            DropIndex("dbo.Services", new[] { "City_Id" });
            DropIndex("dbo.Offices", new[] { "City_Id" });
            DropTable("dbo.ServicesTypes");
            DropTable("dbo.ServiceOptions");
            DropTable("dbo.Services");
            DropTable("dbo.Offices");
            DropTable("dbo.Cities");
        }
    }
}
