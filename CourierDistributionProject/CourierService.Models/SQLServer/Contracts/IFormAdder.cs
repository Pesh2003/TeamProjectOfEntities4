using CourierService.DbContext.SQLServer;
using CourierService.DbContext.SQLServer.QueryHelpClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Models.SQLServer.Contracts
{
    public interface IQueriesDeliveryItem
    {
        IList<string> AddOfficeToForm(ICorierServiceContext dbContext);

        ServiceOptionQuery AddOptionsToForm(ICorierServiceContext dbContext);

        IList<string> AddCityToForm(ICorierServiceContext dbContext);

        void QueryAllServicesOfGivenUser(ICorierServiceContext dbContext, int userId);
    }
}
