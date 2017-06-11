using SQLServerDbContext.DbConfigModel;
using System.Collections.Generic;
using System.Linq;

namespace SQLServerDbContext.Model
{
    public class DbConnection
    {
        public IList<User> GetUsers()
        {
            var users = new List<User>();
            using (var dbContext = new TestModel())
            {
                dbContext.Database.Connection.Open();
                users = dbContext
                    .Users
                    .OrderBy(m => m.Username)
                    .ThenBy(m => m.Password)
                    .ToList();
                
                dbContext.Database.Connection.Dispose();
            }
            return users;
        }
    }
}
