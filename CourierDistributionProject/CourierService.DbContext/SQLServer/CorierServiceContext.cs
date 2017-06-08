namespace CourierService.DbContext.SQLServer
{
    using CourierService.DbContextModels.SQLServer;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Annotations;

    public class CorierServiceContext : DbContext
    {
        public CorierServiceContext() : base("CorierServiceContextConection")
        {

        }

        public DbSet<Office> Offices { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<ServicesType> ServicesTypes { get; set; }

        public DbSet<ServiceOption> ServiceOptions { get; set; }

        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.OnServicesTypeModelCreating(modelBuilder);
            
            base.OnModelCreating(modelBuilder);
        }

        private void OnServicesTypeModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServicesType>().Property( stype => stype.ServiceType).HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("IX_ServicesType") { IsUnique = true }));
        }
    }
}
