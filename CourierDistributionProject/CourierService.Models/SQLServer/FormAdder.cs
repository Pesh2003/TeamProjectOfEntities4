using CourierService.DbContext.SQLServer;
using CourierService.DbContext.SQLServer.QueryHelpClasses;
using CourierService.Models.SQLServer.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Models.SQLServer
{
    public class FormAdder : IFormAdder
    {
        private ICommandParser commandParser;

        public FormAdder(ICommandParser commandParser)
        {
            this.commandParser = commandParser;

        }

        public IList<string> AddOfficeToForm(ICorierServiceContext dbContext)
        {
            var result = new List<string>();

            int countOffices = 0;
            string cityNameOffice = null;
            string addressOffice = null;

            var allOffices = from offis in dbContext.Offices
                             join citi in dbContext.Cities
                             on offis.CityId equals citi.Id
                             orderby citi.CityName
                             select new
                             {
                                 offceId = offis.Id,
                                 address = offis.Address,
                                 cityName = citi.CityName
                             };

            foreach (var item in allOffices.ToList())
            {
                Console.WriteLine($"  {item.offceId} {item.cityName}  {item.address}");
                countOffices++;
            }

            var officeChosen = commandParser.CommandParse(countOffices, "Offices");

            foreach (var item in allOffices)
            {
                if (item.offceId == officeChosen)
                {
                    cityNameOffice = item.cityName;
                    addressOffice = item.address;
                    break;
                }
            }
            result.Add(cityNameOffice);
            result.Add(addressOffice);

            return result;
        }


        public ServiceOptionQuery AddOptionsToForm(ICorierServiceContext dbContext)
        {
            var helpQuery = new ServiceOptionQuery();

            int counterOptions = 0;

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
            Console.WriteLine("Num | Weight |  Price |  TimeDuration | ServicesType");

            foreach (var item in serviceOptions)
            {
                Console.WriteLine($"{item.Id}    {item.Weight}       {item.Price}       {item.TimeDuration}              {item.ServiceType}");
                counterOptions++;
            }
            Console.WriteLine("-----");


            var typeChosen = commandParser.CommandParse(counterOptions, "ServiceOption");

            foreach (var item in serviceOptions)
            {
                if (typeChosen == item.Id)
                {
                    helpQuery.Weight = item.Weight;
                    helpQuery.Price = item.Price;
                    helpQuery.TimeDuration = item.TimeDuration;
                    helpQuery.ServiceType = item.ServiceType;
                    break;
                }
            }
            return helpQuery;
        }
    }    
}
