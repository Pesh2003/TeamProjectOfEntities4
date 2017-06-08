using CourierService.DbContextModels.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.DbContext.SQLServer.InitialDataToLoad
{
    class DataServiceOptions
    {
        internal void AddServiceOptions()
        {
            var dbContext = new CorierServiceContext();

            var servOption1 = new ServiceOption()
            {
                Weight = 5,
                Price = 8.99m,
                TimeDuration = 3,
                ServicesType = dbContext.ServicesTypes.Find(1)
            };

            var servOption2 = new ServiceOption()
            {
                Weight = 10,
                Price = 15.60m,
                TimeDuration = 3,
                ServicesType = dbContext.ServicesTypes.Find(1)
            };

            var servOption3 = new ServiceOption()
            {
                Weight = 15,
                Price = 22.30m,
                TimeDuration = 3,
                ServicesType = dbContext.ServicesTypes.Find(1)
            };

            var servOption4 = new ServiceOption()
            {
                Weight = 5,
                Price = 16.30m,
                TimeDuration = 2,
                ServicesType = dbContext.ServicesTypes.Find(2)
            };

            var servOption5 = new ServiceOption()
            {
                Weight = 10,
                Price = 34.80m,
                TimeDuration = 2,
                ServicesType = dbContext.ServicesTypes.Find(2)
            };

            var servOption6 = new ServiceOption()
            {
                Weight = 15,
                Price = 60.28m,
                TimeDuration = 1,
                ServicesType = dbContext.ServicesTypes.Find(2)
            };

            var servOption7 = new ServiceOption()
            {
                Weight = 5,
                Price = 7.80m,
                TimeDuration = 5,
                ServicesType = dbContext.ServicesTypes.Find(3)
            };

            var servOption8 = new ServiceOption()
            {
                Weight = 10,
                Price = 11.20m,
                TimeDuration = 5,
                ServicesType = dbContext.ServicesTypes.Find(3)
            };

            var servOption9 = new ServiceOption()
            {
                Weight = 15,
                Price = 18.46m,
                TimeDuration = 5,
                ServicesType = dbContext.ServicesTypes.Find(3)
            };

            dbContext.ServiceOptions.Add(servOption1);
            dbContext.ServiceOptions.Add(servOption2);
            dbContext.ServiceOptions.Add(servOption3);
            dbContext.ServiceOptions.Add(servOption4);
            dbContext.ServiceOptions.Add(servOption5);
            dbContext.ServiceOptions.Add(servOption6);
            dbContext.ServiceOptions.Add(servOption7);
            dbContext.ServiceOptions.Add(servOption8);
            dbContext.ServiceOptions.Add(servOption9);

            dbContext.SaveChanges();
        }
    }
}
