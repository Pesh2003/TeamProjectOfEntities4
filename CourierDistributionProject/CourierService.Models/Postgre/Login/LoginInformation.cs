using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationModels.Model.Input;
using ApplicationModels.Model.Output;
using CourierService.DbContext.Postgre.InitialDataToLoad;

namespace CourierService.Models.Postgre.Login
{
   public class LoginInformation
    {
        public IList<string> GetLoginInformation()
        {
            List<string> userInfo = new List<string>();

            ConsoleOutput.PrintLine("Enter Username");
            var username = ConsoleInput.ReadLine();
            userInfo.Add(username);

            ConsoleOutput.PrintLine("Enter Password");
            var password = ConsoleInput.ReadLine();
            var hashedPassword = Hasher.GetMD5(password);
            userInfo.Add(hashedPassword);

            return userInfo;
        }
    }
}
