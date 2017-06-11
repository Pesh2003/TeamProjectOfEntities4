using ApplicationModels.Model.Output;
using SQLServerDbContext.Model;

namespace ApplicationModels.Model.SQLServerConnection
{
    internal static class ApplicationModel
    {
        internal static void PrintUsersInformation()
        {
            var dbConnection = new DbConnection();
            var users = dbConnection.GetUsers();
            foreach (var user in users)
            {
                ConsoleOutput.PrintLine(string.Format($"{user.Username}, {user.Password}"));
            }
        }
    }
}
