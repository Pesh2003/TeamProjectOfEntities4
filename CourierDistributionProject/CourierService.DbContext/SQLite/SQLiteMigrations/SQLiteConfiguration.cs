//namespace CourierService.DbContext.SQLite.SQLiteMigrations
//{
//    using System;
//    using System.Data.Entity;
//    using System.Data.Entity.Migrations;
//    using System.Linq;

//    public sealed class SQLiteConfiguration : DbMigrationsConfiguration<CourierService.DbContext.SQLite.VehiclesDbContext>
//    {
//        public SQLiteConfiguration()
//        {
//            this.AutomaticMigrationsEnabled = false;
//            this.AutomaticMigrationDataLossAllowed = false;
//            this.MigrationsDirectory = @"SQLite\SQLiteMigrations";
//        }

//        protected override void Seed(CourierService.DbContext.SQLite.VehiclesDbContext context)
//        {
//            //  This method will be called after migrating to the latest version.

//            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
//            //  to avoid creating duplicate seed data. E.g.
//            //
//            //    context.People.AddOrUpdate(
//            //      p => p.FullName,
//            //      new Person { FullName = "Andrew Peters" },
//            //      new Person { FullName = "Brice Lambson" },
//            //      new Person { FullName = "Rowan Miller" }
//            //    );
//            //
//        }
//    }
//}
