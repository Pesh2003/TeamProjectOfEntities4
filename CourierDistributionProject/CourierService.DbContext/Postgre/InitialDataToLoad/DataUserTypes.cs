using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierService.DbContextModels.Postgre;

namespace CourierService.DbContext.Postgre.InitialDataToLoad
{
   public class DataUserTypes
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
