using CourierService.DbContext.SQLServer;
using CourierService.Models.SQLServer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Models.SQLServer.DistributionFixer
{
    public class DistributionReleaser : IDistributionReleaser
    {
        public void CloseDistribution(ICorierServiceContext dbContext, IQueriesFixer distributions, ICommandParser comandParser, int userId)
        {
            var notClosedItemsId = new List<int>();
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            var distribClose = dbContext.Services
                .Where(g => g.UserFixerId == userId).Where(t => t.IsCompleted == false)
                .Select(s => new { s.Id, s.Details, s.City.CityName, s.ServiceOption, s.City }).ToList();

            foreach (var item in distribClose)
            {
                Console.WriteLine(" {0}  {1} --> {2}", item.Id, item.Details, item.CityName);
                notClosedItemsId.Add(item.Id);
            }

            Console.WriteLine();
            Console.WriteLine(" Please enter distribution to close");
            Console.WriteLine("------------------------------------------");
            var serviceItemToClose = comandParser.CommandParse(notClosedItemsId, "Destribution");
            int servOptId = 0;
            int citiIdd = 0;
            foreach (var item in distribClose)
            {
                if (serviceItemToClose == item.Id)
                {
                    Console.WriteLine(" You want to close distribution -->  Y / N");
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine(" | {0} --> {1} |", item.Details, item.CityName);
                    servOptId = item.ServiceOption.Id;
                    citiIdd = item.City.Id;
                }
            }
            if (Console.ReadLine().ToLower() == "y")
            {

                var n = dbContext.Services.Find(serviceItemToClose);
                n.IsCompleted = true;
                n.ServiceOption = dbContext.ServiceOptions.Find(servOptId);
                n.City = dbContext.Cities.Find(citiIdd);

                dbContext.SaveChanges();
                Console.WriteLine(" Your order is processed");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(" If you what to exit this service type \" EXIT \" ");
                if (Console.ReadLine().ToLower() == "exit")
                {
                    return;
                }
            }
        }
    }    
}
