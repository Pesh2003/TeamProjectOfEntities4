using System.Data.Entity;
using CourierService.DbContextModels.Postgre;

namespace CourierService.DbContext.Postgre
{
   public class UsersDbContext : System.Data.Entity.DbContext
    {
        public UsersDbContext() : base("UserConnection")
        {

        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UsersType> UsersType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<User>()
                .HasRequired<UsersType>(s => s.UserType)
                .WithMany(s => s.Users);

        }
    }
}
