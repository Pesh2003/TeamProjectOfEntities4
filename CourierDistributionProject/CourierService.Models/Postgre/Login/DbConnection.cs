using System.Collections.Generic;
using System.Linq;
using CourierService.DbContext.Postgre;
using CourierService.DbContextModels.Postgre;
namespace CourierService.Models.Postgre.Login
{
    public class DbConnection : IDbConnection
    {
        public IList<User> GetUser(string username, string hashedPassword)
        {
            var user = new List<User>();
            using (var db = new UsersDbContext())
            {
                user = db.Users
                    .Where(n => n.Username.Equals(username) && n.Password.Equals(hashedPassword))
                    .ToList();
            }
            return user;
        }
    }
}
