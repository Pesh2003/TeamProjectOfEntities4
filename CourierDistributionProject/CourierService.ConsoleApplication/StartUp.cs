using CourierService.DbContext.SQLServer;
using CourierService.DbContext.SQLServer.InitialDataToLoad;
using CourierService.DbContextModels.SQLServer;
using System;
using CourierService.DbContext.PostgreSQL.DataToLoad;

namespace CourierService.ConsoleApplication
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var initialDataToSQLServer = new InicialDataToSQLServer();
            initialDataToSQLServer.InitialDataToSQLServeLoad();

            var initialDataToPostgreSqlServer = new InitialDataToPostgreSQL();
            initialDataToPostgreSqlServer.InitialDataToPostgreSQLLoad();
        }        
    }
}

