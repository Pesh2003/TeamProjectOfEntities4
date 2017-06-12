namespace CourierService.DbContext.PostgreSQLMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                        UserTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.UsersTypes", t => t.UserTypeId, cascadeDelete: true)
                .Index(t => t.Username, unique: true)
                .Index(t => t.UserTypeId);
            
            CreateTable(
                "public.UsersTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserType = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.Users", "UserTypeId", "public.UsersTypes");
            DropIndex("public.Users", new[] { "UserTypeId" });
            DropIndex("public.Users", new[] { "Username" });
            DropTable("public.UsersTypes");
            DropTable("public.Users");
        }
    }
}
