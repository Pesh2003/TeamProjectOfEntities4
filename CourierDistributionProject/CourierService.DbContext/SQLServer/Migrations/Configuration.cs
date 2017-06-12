namespace CourierService.DbContext.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CourierService.DbContext.SQLServer.CorierServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CourierService.DbContext.SQLServer.CorierServiceContext context)
        {
            
        }
    }
}
