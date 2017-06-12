using CourierService.DbContext.SQLServer;
using CourierService.DbContext.SQLServer.InitialDataToLoad;
using CourierService.DbContext.SQLServer.QueryHelpClasses;
using CourierService.DbContextModels.SQLServer;
using CourierService.Models.SQLServer;
using CourierService.Models.SQLServer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CourierService.ConsoleApplication
{
    class StartUpSQL1
    {
        static void Mainn(string[] args)
        {
            //var initialDataToSQLServer = new InicialDataToSQLServer();
            //initialDataToSQLServer.InitialDataToSQLServeLoad();
            
            // 1 Declare an item for delivery
            // 2 Get an Item to deliver (Fixer)
            ICommandParser comandParser = new CommandParser();
            ICorierServiceContext dbContext = new CorierServiceContext();
            var entryPointSQL = new EntryPointToSQL(dbContext, comandParser);

            while (true)
            {
                var parsedCommand = entryPointSQL.Header();
                if (parsedCommand == 0)
                {
                    break;
                }

                Console.WriteLine("Enter UserId");
                int userId = int.Parse(Console.ReadLine());

                if (parsedCommand == 1)
                {
                    entryPointSQL.AssignItams(userId);
                }
                else
                {
                    entryPointSQL.CommitDistribution(userId);
                }
            }
        }
    }
}




