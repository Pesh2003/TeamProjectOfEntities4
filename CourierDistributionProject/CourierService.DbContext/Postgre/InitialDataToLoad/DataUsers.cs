using CourierService.DbContextModels.Postgre;

namespace CourierService.DbContext.Postgre.InitialDataToLoad
{
   public class DataUsers
    {
            internal void AddUsers()
            {
                var dbContext = new UsersDbContext();

                var firstUser = new User()
                {
                    Username = "Followerie",
                    Password = Hasher.GetMD5("123456"),
                    Description = "Some Description",
                    UserType = dbContext.UsersType.Find(1)
                };

                var secondUser = new User()
                {
                    Username = "Ambsace",
                    Password = Hasher.GetMD5("234567"),
                    Description = "Some Description",
                    UserType = dbContext.UsersType.Find(2)
                };

                var thirdUser = new User()
                {
                    Username = "Abderian",
                    Password = Hasher.GetMD5("345678"),
                    Description = "Some Description",
                    UserType = dbContext.UsersType.Find(2)
                };

                var fourthUser = new User()
                {
                    Username = "Cernuous",
                    Password = Hasher.GetMD5("456789"),
                    Description = "Some Description",
                    UserType = dbContext.UsersType.Find(2)
                };

                var fifthUser = new User()
                {
                    Username = "Boeotian",
                    Password = Hasher.GetMD5("567890"),
                    Description = "Some Description",
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
