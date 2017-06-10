using CourierService.DbContext.SQLServer;
using CourierService.DbContext.SQLServer.InitialDataToLoad;
using CourierService.DbContext.SQLServer.QueryHelpClasses;
using CourierService.DbContextModels.SQLServer;
using CourierService.Models.SQLServer;
using CourierService.Models.SQLServer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CourierService.ConsoleApplication
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //var initialDataToSQLServer = new InicialDataToSQLServer();
            //initialDataToSQLServer.InitialDataToSQLServeLoad();

            // what service would you like to get :)
            // 1 Declare an item for delivery
            // 2 Get an Item to deliver by own vehicle

            while (true)
            {
                Console.WriteLine("Choose service");
                var command = Console.ReadLine().ToLower();
                int parsedCommand = 0;

                if (int.TryParse(command, out parsedCommand) && (parsedCommand == 1 || parsedCommand == 2))
                {
                    // Console.WriteLine(parsedCommand);
                    if (parsedCommand == 1)
                    {
                        ICorierServiceContext dbCont = new CorierServiceContext();
                        ICommandParser comandPars = new CommandParser();
                        IFormAdder fomrAdd = new FormAdder(comandPars);
                        var n = new DeliveryItem(dbCont, fomrAdd);
                        n.declareItem();
                    }
                    else
                    {
                        break;
                    }
                }
                if (command == "exit")
                {
                    break;
                }
            }
        }       
    }
}

