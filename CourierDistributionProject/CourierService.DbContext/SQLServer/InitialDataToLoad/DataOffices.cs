using CourierService.DbContextModels.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.DbContext.SQLServer.InitialDataToLoad
{
    class DataOffices
    {
       internal void AddOffices()
        {
            var dbContext = new CorierServiceContext();

            var office1 = new Office
            {
                Address = "ул. Мария Луиза 56",
                City = dbContext.Cities.Find(2)
            };

            var office2 = new Office
            {
                Address = "кв. Павлово, ул. Незабравка 167",
                City = dbContext.Cities.Find(2)
            };

            var office3 = new Office
            {
                Address = "ул. Аполония 42",
                City = dbContext.Cities.Find(1)
            };

            var office4 = new Office
            {
                Address = "кв. Храбрино бл.28 вх.А ет.3 ап.67",
                City = dbContext.Cities.Find(4)
            };

            var office5 = new Office
            {
                Address = "ул.Детелина 79",
                City = dbContext.Cities.Find(3)
            };

            var office6 = new Office
            {
                Address = "кв. Слатина бл.53 вх.Д ет.12 ап.73",
                City = dbContext.Cities.Find(2)
            };

            dbContext.Offices.Add(office1);
            dbContext.Offices.Add(office2);
            dbContext.Offices.Add(office3);
            dbContext.Offices.Add(office4);
            dbContext.Offices.Add(office5);
            dbContext.Offices.Add(office6);

            dbContext.SaveChanges();
        }
    }
}
