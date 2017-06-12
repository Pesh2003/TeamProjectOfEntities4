using CourierService.DbContext.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Models.SQLServer.Contracts
{
    public interface IDistributionReleaser
    {
        void CloseDistribution(ICorierServiceContext dbContext, IQueriesFixer distributions, ICommandParser comandParser, int userId);
    }
}
