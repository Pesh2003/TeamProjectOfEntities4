using CourierService.DbContext.SQLServer;
using CourierService.DbContext.SQLServer.InitialDataToLoad;
using CourierService.DbContextModels.SQLServer;
using System;

namespace CourierService.ConsoleApplication
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var initialDataToSQLServer = new InicialDataToSQLServer();
            initialDataToSQLServer.InitialDataToSQLServeLoad();
        }        
    }
}

