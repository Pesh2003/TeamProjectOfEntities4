using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierService.DbContext.Postgre;
using CourierService.DbContextModels.Postgre;

namespace CourierService.Models.Postgre.Register
{
   public class DbUserConnection
    {
        public void RegisterUser(string username, string hashedPassword, string description, int userType)
        {
            using (var db = new UsersDbContext())
            {
                var user = new User()
                {

                    Username = username,
                    Password = hashedPassword,
                    Description = description,
                    UserType = db.UsersType.Find(userType)
                };
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
    }
}
