﻿namespace CourierService.DbContext.SQLServer
{
    using CourierService.DbContextModels.SQLServer;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Annotations;

    public class CorierServiceContext : DbContext, ICorierServiceContext
    {
        public CorierServiceContext() : base("CorierServiceContextConection")
        {

        }

        public virtual IDbSet<Office> Offices { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<ServicesType> ServicesTypes { get; set; }

        public virtual IDbSet<ServiceOption> ServiceOptions { get; set; }

        public virtual IDbSet<Service> Services { get; set; }

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

    public interface ICorierServiceContext
    {
        int SaveChanges();

        IDbSet<Office> Offices { get; set; }

        IDbSet<City> Cities { get; set; }

        IDbSet<ServicesType> ServicesTypes { get; set; }

        IDbSet<ServiceOption> ServiceOptions { get; set; }

        IDbSet<Service> Services { get; set; }
    }
}
