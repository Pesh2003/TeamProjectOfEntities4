namespace CourierService.DbContext.SQLServerMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class SQLConfiguration : DbMigrationsConfiguration<CourierService.DbContext.SQLServer.CorierServiceContext>
    {
        public SQLConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"SQLServerMigrations";
        }

        protected override void Seed(CourierService.DbContext.SQLServer.CorierServiceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
