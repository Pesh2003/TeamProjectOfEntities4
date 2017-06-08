using CourierService.DbContextModels.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.DbContext.SQLServer.InitialDataToLoad
{
    class DataServiceTypes
    {
        internal void AddServiceTypes()
        {
            var dbContext = new CorierServiceContext();

            var serviceType1 = new ServicesType() { ServiceType = "Regular" };
            var serviceType2 = new ServicesType { ServiceType = "Express" };
            var serviceType3 = new ServicesType { ServiceType = "Economy" };

            dbContext.ServicesTypes.Add(serviceType1);
            dbContext.ServicesTypes.Add(serviceType2);
            dbContext.ServicesTypes.Add(serviceType3);

            dbContext.SaveChanges();
        }
    }
}
