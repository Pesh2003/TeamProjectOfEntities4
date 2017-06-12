using CourierService.DbContext.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Models.SQLServer.Contracts
{
    public interface IQueriesFixer
    {
        void ServiceOptionDetails(ICorierServiceContext dbContext, int serviceId);

        IList<int> AvailableDistributionItems(ICorierServiceContext dbContext);
    }
}
