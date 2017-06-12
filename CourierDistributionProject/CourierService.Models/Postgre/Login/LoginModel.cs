using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationModels.Model.Output;
using CourierService.DbContextModels.Postgre;

namespace CourierService.Models.Postgre.Login
{
    public class LoginModel
    {
        public static IList<User> UserLogin()
        {
            var userinformation = new LoginInformation();
            var userInfo = userinformation.GetLoginInformation();

            var username = userInfo.ElementAt(0);
            var hashedPassword = userInfo.ElementAt(1);

            var dbConnection = new DbConnection();
            var users = dbConnection.GetUser(username, hashedPassword);
            int listCount = ((IList)users).Count;

            if (listCount != 1)
            {
                ConsoleOutput.PrintLine("Invalid Username or Password");
            }
            else
            {
                ConsoleOutput.PrintLine("You have successfully logged in");
             
             var details = new UserDetails();
             var loggedUser = details.GetUsername(username);

                return loggedUser;
            }

            return null;

        }
    }
}
