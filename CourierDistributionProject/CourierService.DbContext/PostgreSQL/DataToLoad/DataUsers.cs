using CourierService.DbContextModels.PostgreSQL;

namespace CourierService.DbContext.PostgreSQL.DataToLoad
{
    class DataUsers
    {
        internal void AddUsers()
        {
            var dbContext = new UsersDbContext();

            var firstUser = new User()
            {
                Username = "Followerie",
                Password = "123456",
                Description = "Some Random Description 1",
                UserType = dbContext.UsersType.Find(1)
            };

            var secondUser = new User()
            {
                Username = "Ambsace",
                Password = "234567",
                Description = "Some Random Description 2",
                UserType = dbContext.UsersType.Find(2)
            };

            var thirdUser = new User()
            {
                Username = "Abderian",
                Password = "345678",
                Description = "Some Random Description 3",
                UserType = dbContext.UsersType.Find(2)
            };

            var fourthUser = new User()
            {
                Username = "Cernuous",
                Password = "456789",
                Description = "Some Random Description 4",
                UserType = dbContext.UsersType.Find(2)
            };

            var fifthUser = new User()
            {
                Username = "Boeotian",
                Password = "567890",
                Description = "Some Random Description 5",
                UserType = dbContext.UsersType.Find(1)
            };

            dbContext.Users.Add(firstUser);
            dbContext.Users.Add(secondUser);
            dbContext.Users.Add(thirdUser);
            dbContext.Users.Add(fourthUser);
            dbContext.Users.Add(fifthUser);

            dbContext.SaveChanges();

        }
    }
}
