using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationModels.Model.Input;
using ApplicationModels.Model.Output;
using CourierService.DbContext.Postgre.InitialDataToLoad;

namespace CourierService.Models.Postgre.Register
{
   public class RegistrationInformation
    {
        public IList<string> GetRegistrationInformation()
        {
            List<string> userInfo = new List<string>();

            ConsoleOutput.PrintLine("Enter Username");
            var username = ConsoleInput.ReadLine();
            while (username.Length < 6 ||
                   username.Length > 20)

            {
                ConsoleOutput.PrintLine("Error invalid username!");

                ConsoleOutput.PrintLine("Enter username: ");
                username = ConsoleInput.ReadLine();

            }
            userInfo.Add(username);

            ConsoleOutput.PrintLine("Enter Password");
            var password = ConsoleInput.ReadLine();
            while (password.Length < 1 ||
                   password.Length > 20)
            {
                ConsoleOutput.PrintLine("You have entered invalid password!");

                ConsoleOutput.PrintLine("Enter password: ");
                password = ConsoleInput.ReadLine();
            }
            var hashedPassword = Hasher.GetMD5(password);
            userInfo.Add(hashedPassword);

            ConsoleOutput.PrintLine("Enter Description");
            var description = ConsoleInput.ReadLine();
            userInfo.Add(description);

            ConsoleOutput.PrintLine("Enter UserType: \n " +
                                    "1 - Service Creator\n" +
                                    "2 - Service Fixer");

            var userType = ConsoleInput.ReadLine();
            userInfo.Add(userType);

            return userInfo;
        }
    }
}
