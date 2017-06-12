using CourierService.DbContext.SQLServer;
using CourierService.Models.SQLServer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Models.SQLServer.DistributionFixer
{
    class DistributionPicker : IDistributionPicker
    {
        public void PickUpDistribution(ICorierServiceContext dbContext, IQueriesFixer distributions, ICommandParser comandParser, int userId)
        {
            var serviceIdList = distributions.AvailableDistributionItems(dbContext);
            if (serviceIdList.Count == 0)
            {
                Console.WriteLine("There is not available items for distribution");
                return;
            }
            else
            {
                Console.WriteLine("Get more detail by number");
            }

            var serviceId = comandParser.CommandParse(serviceIdList, "Service Options");
            var serviceAll = dbContext.Services
                          .Where(s => s.Id == serviceId)
                          .Select(t => new { t.ServiceOption, t.City })
                          .ToList();

            distributions.ServiceOptionDetails(dbContext, serviceAll[0].ServiceOption.Id);
            Console.WriteLine("Commit to Distribution -->  Y / N");

            if (Console.ReadLine().ToLower() == "y")
            {
                var n = dbContext.Services.Find(serviceId);
                n.IsTaken = true;
                n.UserFixerId = userId;
                n.ServiceOption = dbContext.ServiceOptions.Find(serviceAll[0].ServiceOption.Id);
                n.City = dbContext.Cities.Find(serviceAll[0].City.Id);

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
