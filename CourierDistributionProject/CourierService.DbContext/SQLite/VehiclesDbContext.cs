using CourierService.DbContext.SQLite;
using CourierService.DbContextModels.SQLite;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.DbContext.SQLite
{
    public class VehiclesDbContext
    {
        public VehiclesDbContext()
        {
        }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Brand> Brands { get; set; }

        //public virtual DbSet<Model> Models { get; set; }

        public virtual DbSet<Vehicle> Vehicles { get; set; }
    }
}
