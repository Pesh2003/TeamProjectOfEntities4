namespace CourierService.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inisial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "UserFixerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "UserFixerId");
        }
    }
}
