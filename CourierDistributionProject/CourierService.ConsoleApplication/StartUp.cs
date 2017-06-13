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
using CourierService.DbContext.Postgre.InitialDataToLoad;
using CourierService.Models;
using CourierService.DbContext.SQLite;

namespace CourierService.ConsoleApplication
{
   public class StartUp
    {
       public static void Main(string[] args)
        {
            // var initialDataToSQLServer = new InicialDataToSQLServer();
            // initialDataToSQLServer.InitialDataToSQLServeLoad();

            // var initialDataToPostgreSQL = new InitialDataToPostgreSQL();
            // initialDataToPostgreSQL.InicialDataToPostgreSQLLoad();
            
            var application = new ApplicationTest();
            application.Run();
        }
    }
}




