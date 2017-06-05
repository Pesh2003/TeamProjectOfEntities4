namespace ConsoleTestApplication01
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            // PostgreSQL connection test
            var postgreSql = TestPostgreSQLConnection.GetUsers();
            foreach (var item in postgreSql)
            {
                Console.WriteLine($"{item.Id} {item.Username} {item.Password} {item.Description} {item.UserTypeId}");
            }

            // Console.WriteLine("---");
            // SQLite connection test
            TestSqLiteConnection.CreateFile();
            TestSqLiteConnection.CreateDb();
            //var sqLite = TestSqLiteConnection.GetUsers();
            //foreach (var item in sqLite)
            //{
            //    Console.WriteLine($"{item.Id} {item.Name}");
            //}

            Console.WriteLine("---");
            // SQL Server connection test
            var sqlServer = TestSQLServerConnection.GetServices();
            foreach (var item in sqlServer)
            {
                Console.WriteLine($"{item.Id} {item.Name}");
            }
        }
    }
}
