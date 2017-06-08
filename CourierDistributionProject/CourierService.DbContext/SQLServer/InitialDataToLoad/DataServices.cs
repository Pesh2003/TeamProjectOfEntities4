using CourierService.DbContextModels.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.DbContext.SQLServer.InitialDataToLoad
{
    class DataServices
    {
        internal void AddServices()
        {
            var dbContext = new CorierServiceContext();

            var service1 = new Service()
            {
                Details = "Лаптоп",
                IsTaken = false,
                City = dbContext.Cities.Find(1),
                ServiceOption = dbContext.ServiceOptions.Find(7),
                CreateDate = DateTime.Now,
                OfficeId = 1
            };

            var service2 = new Service()
            {
                Details = "Монитор",
                IsTaken = false,
                City = dbContext.Cities.Find(5),
                ServiceOption = dbContext.ServiceOptions.Find(5),
                CreateDate = DateTime.Now,
                OfficeId = 3
            };

            var service3 = new Service()
            {
                Details = "Книги",
                IsTaken = false,
                City = dbContext.Cities.Find(4),
                ServiceOption = dbContext.ServiceOptions.Find(3),
                CreateDate = DateTime.Now,
                OfficeId = 6
            };

            var service4 = new Service()
            {
                Details = "Холна маса",
                IsTaken = false,
                City = dbContext.Cities.Find(2),
                ServiceOption = dbContext.ServiceOptions.Find(8),
                CreateDate = DateTime.Now,
                OfficeId = 4
            };

            var service5 = new Service()
            {
                Details = "Дрехи",
                IsTaken = false,
                City = dbContext.Cities.Find(1),
                ServiceOption = dbContext.ServiceOptions.Find(5),
                CreateDate = DateTime.Now,
                OfficeId = 1
            };

            var service6 = new Service()
            {
                Details = "Канцеларски материали",
                IsTaken = false,
                City = dbContext.Cities.Find(4),
                ServiceOption = dbContext.ServiceOptions.Find(2),
                CreateDate = DateTime.Now,
                OfficeId = 1
            };

            dbContext.Services.Add(service1);
            dbContext.Services.Add(service2);
            dbContext.Services.Add(service3);
            dbContext.Services.Add(service4);
            dbContext.Services.Add(service5);
            dbContext.Services.Add(service6);

            dbContext.SaveChanges();
        }
    }
}
