using System.Collections.Generic;
using System.Linq;
using CourierService.DbContext.Postgre;
using CourierService.DbContextModels.Postgre;

namespace CourierService.Models.Postgre.Login
{
   public class UserDetails
    {
        public IList<User> GetUsername(string username)
        {
            var user = new List<User>();
            using (var db = new UsersDbContext())
            {
               user = db.Users
                    .Where(n => n.Username.Equals(username))
                    .ToList();
            }

            return user;
        }
    }
}
