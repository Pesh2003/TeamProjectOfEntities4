using CourierService.DbContext.SQLServer;
using CourierService.DbContext.SQLServer.QueryHelpClasses;
using CourierService.Models.SQLServer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationModels.Model.Input;
using ApplicationModels.Model.Output;

namespace CourierService.Models.SQLServer
{
    public class QueriesDeliveryItem : IQueriesDeliveryItem
    {
        private ICommandParser commandParser;

        public QueriesDeliveryItem(ICommandParser commandParser)
        {
            this.commandParser = commandParser;

        }

        public IList<string> AddOfficeToForm(ICorierServiceContext dbContext)
        {
            var result = new List<string>();
            
            string cityNameOffice = null;
            string addressOffice = null;
            int officeId = 0;

            var allOffices = from offis in dbContext.Offices
                             join citi in dbContext.Cities
                             on offis.CityId equals citi.Id                             
                             select new
                             {
                                 offceId = offis.Id,
                                 address = offis.Address,
                                 cityName = citi.CityName
                             };

            var officeIdList = new List<int>();
            foreach (var item in allOffices.OrderBy(t => t.cityName).ThenBy(f => f.offceId))
            {               
                ConsoleOutput.PrintLine($"  {item.offceId} {item.cityName}  {item.address}");
                officeIdList.Add(item.offceId);
            }

            var officeChosen = commandParser.CommandParse(officeIdList, "Offices");
            if (officeChosen == 0)
            {
                return null;
            }

            foreach (var item in allOffices)
            {         
                if (item.offceId == officeChosen)
                {
                    officeId = item.offceId;
                    cityNameOffice = item.cityName;
                    addressOffice = item.address;
                    break;
                }
            }
            result.Add(officeId.ToString());
            result.Add(cityNameOffice);
            result.Add(addressOffice);            
           
            return result;
        }
        // -------------------------------------------------------------------------
        
        public ServiceOptionQuery AddOptionsToForm(ICorierServiceContext dbContext)
        {
            var helpQuery = new ServiceOptionQuery();            

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

            ConsoleOutput.PrintLine("Num | Weight |  Price |  TimeDuration | ServicesType");

            var serviceOptionsIdList = new List<int>();
            foreach (var item in serviceOptions)
            {
                
                ConsoleOutput.PrintLine($" {item.Id}    {item.Weight}       {item.Price}       {item.TimeDuration}              {item.ServiceType}");
                serviceOptionsIdList.Add(item.Id);
            }
            ConsoleOutput.PrintLine("-----");


            var typeChosen = commandParser.CommandParse(serviceOptionsIdList, "ServiceOption");

            foreach (var item in serviceOptions)
            {
                if (typeChosen == item.Id)
                {
                    helpQuery.ServOptionId = item.Id;
                    helpQuery.Weight = item.Weight;
                    helpQuery.Price = item.Price;
                    helpQuery.TimeDuration = item.TimeDuration;
                    helpQuery.ServiceType = item.ServiceType;
                    break;
                }
            }
            return helpQuery;
        }
        // ----------------------------------------------------------------

        public IList<string> AddCityToForm(ICorierServiceContext dbContext)
        {
            var result = new List<string>();
            var destinationCity = ConsoleInput.ReadLine();
            var cityName = dbContext.Cities.Select(t => t.CityName).ToList();

            cityName.Sort();

            var cityNameLower = cityName.ConvertAll(d => d.ToLower());
            var searchCity = cityNameLower.FirstOrDefault<string>(n => n.Equals(destinationCity.ToLower()));

            if (searchCity == null)
            {
                ConsoleOutput.PrintLine(" There is no such a city name \n  (Please type one from the list) ");
               ConsoleOutput.PrintLine("-----------------------------------------------");

                foreach (var item in cityName)
                {
                    Console.WriteLine(" {0}", item);
                }

                bool chekk = true;

                while (chekk)
                {
                    destinationCity = Console.ReadLine();
                    searchCity = cityNameLower.FirstOrDefault<string>(n => n.Equals(destinationCity.ToLower()));

                    if (searchCity != null)
                    {
                        chekk = false;
                    }
                    else
                    {
                        Console.WriteLine(" Please choose a city from the list above");
                    }
                }
            }
            var citiId = dbContext.Cities.Where(c => c.CityName == destinationCity).Select(c => c.Id).ToList();
            result.Add(citiId[0].ToString());
            destinationCity = char.ToUpper(destinationCity[0]) + destinationCity.Substring(1);
            result.Add(destinationCity);
            return result;
        }
        // ----------------------------------------------------------------

        public void QueryAllServicesOfGivenUser(ICorierServiceContext dbContext, int userId)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            var res = dbContext.Services
                .Where(s => s.UserId == userId)
                .Select(t=> new { t.Id, t.Details, t.CreateDate, t.City, t.IsCompleted, t.IsTaken})
                .ToList();
            foreach (var item in res)
            {
                string taken = item.IsTaken ? "on the way" : "in the office";
                string status = item.IsCompleted ? "delivered" : "not delivered";
                Console.WriteLine(" * {0}  -->   {1}  |  {2}",item.Details, taken, status);
                Console.WriteLine();                       
            }
            Console.WriteLine("-----------------------------------------------------");
        }
    }    
}
