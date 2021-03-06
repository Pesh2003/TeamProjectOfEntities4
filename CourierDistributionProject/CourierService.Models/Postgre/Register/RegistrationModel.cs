﻿using System.Linq;
using ApplicationModels.Model.Output;

namespace CourierService.Models.Postgre.Register
{
   public class RegistrationModel
    {
        public static void RegisterUser()
        {
            var userinformation = new RegistrationInformation();
            var userInfo = userinformation.GetRegistrationInformation();

            var username = userInfo.ElementAt(0);
            var hashedPassword = userInfo.ElementAt(1);
            var description = userInfo.ElementAt(2);
            var userType = userInfo.ElementAt(3);
            var userTypeId = int.Parse(userType);

            var dbConnection = new DbUserConnection();
            dbConnection.RegisterUser(username, hashedPassword, description, userTypeId);
            ConsoleOutput.PrintLine("You have registered successfully");
        }
    }
}
