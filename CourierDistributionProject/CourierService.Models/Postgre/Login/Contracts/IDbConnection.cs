using System.Collections.Generic;
using CourierService.DbContextModels.Postgre;

namespace CourierService.Models.Postgre.Login
{
   public interface IDbConnection
   {
       IList<User> GetUser(string username, string hashedPassword);
   }
}
