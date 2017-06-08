namespace CourierService.DbContext.PostgreSQLMigration
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class PostgreSQLConfiguration : DbMigrationsConfiguration<CourierService.DbContext.PostgreSQL.UsersDbContext>
    {
        public PostgreSQLConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"PostgreSQLMigration";
        }

        protected override void Seed(CourierService.DbContext.PostgreSQL.UsersDbContext context)
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
