using CourierService.DbContextModels.PostgreSQL;

namespace CourierService.DbContext.PostgreSQL.DataToLoad
{
    class DataUserTypes
    {
        internal void AddUserTypes()
        {
            var dbContext = new UsersDbContext();

            var firstUsersType = new UsersType() { UserType = "Service Creator" };
            var secondUsersType = new UsersType() { UserType = "Service Fixer" };

            dbContext.UsersType.Add(firstUsersType);
            dbContext.UsersType.Add(secondUsersType);

            dbContext.SaveChanges();
        }
    }
}
