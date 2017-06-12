using CourierService.DbContext.SQLServer;
using CourierService.Models.SQLServer;
using CourierService.Models.SQLServer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Models.SQLServer
{
    public class QueriesFixer : IQueriesFixer
    {
        public IList<int> AvailableDistributionItems(ICorierServiceContext dbContext)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            var dict = new Dictionary<string, string>();
            var serviceId = new List<int>();
            

            var allOffices = from offis in dbContext.Offices
                             join citi in dbContext.Cities
                             on offis.CityId equals citi.Id
                             select new
                             {
                                 offceId = offis.Id,
                                 address = offis.Address,
                                 cityName = citi.CityName
                             };
            foreach (var item in allOffices)
            {
               // Console.WriteLine($"  {item.offceId} {item.cityName}  {item.address}");
                dict.Add(item.offceId.ToString(), item.cityName);
            }

            var res = dbContext.Services
                .Where(s => s.IsTaken == false)
                .Select(t => new { t.Id, t.Details, t.OfficeId, t.City,  })
                .ToList();

            foreach (var item in res)
            {                
                Console.WriteLine(" * {0} | {1} | {2}  -->   {3} ",item.Id , dict[item.OfficeId.ToString()] , item.Details ,item.City.CityName );
                Console.WriteLine();
                serviceId.Add(item.Id);
            }
            Console.WriteLine("-----------------------------------------------------");

            return serviceId;
        }

        public void ServiceOptionDetails(ICorierServiceContext dbContext, int serviceId)
        {
            var serviceOptions = from serOp in dbContext.ServiceOptions
                                 join servTy in dbContext.ServicesTypes
                                 on serOp.ServicesTypeId equals servTy.Id
                                 select new
                                 {
                                     Id = serOp.Id,
                                     Weight = serOp.Weight,
                                     Price = serOp.Price,
                                     TimeDuration = serOp.TimeDuration,
                                     ServiceType = servTy.ServiceType
                                 };

            Console.WriteLine("Num | Weight  |  TimeDuration | ServicesType");

           
            foreach (var item in serviceOptions)
            {
                if (item.Id == serviceId)
                {
                    Console.WriteLine($" {item.Id}    {item.Weight}           {item.TimeDuration}              {item.ServiceType}");
                }              
            }          
        }
    }

    
}
