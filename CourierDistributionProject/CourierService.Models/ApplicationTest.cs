using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationModels.Constant;
using ApplicationModels.Model.Input;
using ApplicationModels.Model.Output;
using CourierService.DbContext.SQLServer;
using CourierService.Models.Postgre.Login;
using CourierService.Models.Postgre.Register;
using CourierService.Models.SQLServer;
using CourierService.Models.SQLServer.Contracts;

namespace CourierService.Models
{
   public class ApplicationTest
    {
        public void Run()
        {
            while (true)
            {
                ConstantInformation.PrintAvailableKeyCodes();
                var keyCommand = ConsoleInput.ReadLine();
                switch (keyCommand)
                {
                    case "1":
                    {
                        RegistrationModel.RegisterUser();
                    }
                        return;
                    case "2":
                    {
                       var user = LoginModel.UserLogin();
                        
                        ICommandParser comandParser = new CommandParser();
                        ICorierServiceContext dbContext = new CorierServiceContext();
                        var entryPointSQL = new EntryPointToSQL(dbContext, comandParser);

                        while (true)
                        {
                          //  var parsedCommand = entryPointSQL.Header();
                          //  if (parsedCommand == 0)
                          //  {
                          //      break;
                          //  }

                            int userId = user[0].Id;
                            int userTypeId = user[0].UserTypeId;

                            if (userTypeId == 1)
                            {
                                entryPointSQL.AssignItams(userId);
                            }
                            else
                            {
                                entryPointSQL.CommitDistribution(userId);
                            }
                        }
                        
                        }
                        break;
                    case "3":
                    {
                        ConsoleOutput.PrintLine(Constant.EXIT_SUCCESSFUL);
                    }
                        return;
                    default:
                    {
                        ConsoleOutput.PrintLine(Constant.WRONG_SYMBOL);
                    }
                        break;
                }
                
            }
        }
    }
}
